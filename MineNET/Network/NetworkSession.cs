using MineNET.Network.RakNetPackets;
using MineNET.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;

namespace MineNET.Network
{
    public class NetworkSession
    {
        #region Static
        public static int WindowSize { get; } = 2048;
        public static int TimedOutTime { get; } = 3000;
        #endregion

        #region Property & Field
        public IPEndPoint EndPoint { get; }
        public long ClientID { get; }
        public short MTUSize { get; }

        public NetworkManager Manager { get; private set; }

        public int LastUpdateTime { get; private set; }

        public int MessageIndex { get; private set; }

        public ConcurrentDictionary<int, int> ACKQueue { get; private set; } = new ConcurrentDictionary<int, int>();
        public ConcurrentDictionary<int, int> NACKQueue { get; private set; } = new ConcurrentDictionary<int, int>();

        public ConcurrentDictionary<int, DataPacket> PacketToSend { get; private set; } = new ConcurrentDictionary<int, DataPacket>();

        public int WindowStart { get; private set; }
        public int WindowEnd { get; private set; }
        public ConcurrentDictionary<int, int> ReceivedWindow { get; private set; } = new ConcurrentDictionary<int, int>();

        public int LastSeqNumber { get; private set; } = -1;

        public int SplitID { get; private set; }
        public int OrderIndex { get; private set; }

        public DataPacket SendQueue = new DataPacket4();
        public Dictionary<int, Dictionary<int, EncapsulatedPacket>> SplitPackets { get; set; } = new Dictionary<int, Dictionary<int, EncapsulatedPacket>>();

        public int ReliableWindowStart { get; private set; }
        public int ReliableWindowEnd { get; private set; }
        public ConcurrentDictionary<int, bool> ReliableWindow { get; private set; } = new ConcurrentDictionary<int, bool>();

        public SessionState State { get; private set; } = SessionState.Connecting;
        #endregion

        #region Ctor Method
        public NetworkSession(IPEndPoint endPoint, long clientID, short mtuSize)
        {
            this.Manager = Server.Instance.Network;

            this.EndPoint = endPoint;
            this.ClientID = clientID;
            this.MTUSize = mtuSize;

            this.LastUpdateTime = NetworkSession.TimedOutTime;

            this.WindowEnd = NetworkSession.WindowSize;
        }
        #endregion

        #region Update Method
        public void OnUpdate()
        {
            if (this.LastUpdateTime < 0)
            {
                this.Disconnect("timedout");
                return;
            }

            if (this.ACKQueue.Count > 0)
            {
                Ack pk = new Ack();
                List<int> pks = new List<int>();
                foreach (KeyValuePair<int, int> kv in this.ACKQueue.ToArray())
                {
                    pks.Add(kv.Value);
                }
                pk.Packets = pks.ToArray();
                this.SendPacket(pk);

                this.ACKQueue.Clear();
            }

            if (this.NACKQueue.Count > 0)
            {
                Nack pk = new Nack();
                List<int> pks = new List<int>();
                foreach (KeyValuePair<int, int> kv in this.NACKQueue.ToArray())
                {
                    pks.Add(kv.Value);
                }
                pk.Packets = pks.ToArray();
                this.SendPacket(pk);

                this.NACKQueue.Clear();
            }

            if (this.PacketToSend.Count > 0)
            {
                int limit = 16;
                foreach (KeyValuePair<int, DataPacket> packet in this.PacketToSend)
                {
                    DataPacket pk = null;
                    //sendEncapsulated
                    this.PacketToSend.TryRemove(packet.Key, out pk);

                    if (--limit <= 0)
                    {
                        break;
                    }
                }

                if (this.PacketToSend.Count > NetworkSession.WindowSize)
                {
                    this.PacketToSend.Clear();
                }
            }

            this.SendQueuePacket();

            --this.LastUpdateTime;
        }
        #endregion

        #region Handle Packet Method
        public void HandleDataPacket(DataPacket packet)
        {
            if (packet.SeqNumber < this.WindowStart || packet.SeqNumber > this.WindowEnd || this.ACKQueue.ContainsKey(packet.SeqNumber))
            {
                return;
            }

            this.LastUpdateTime = this.LastUpdateTime = NetworkSession.TimedOutTime;

            if (this.NACKQueue.ContainsKey(packet.SeqNumber))
            {
                int i;
                this.NACKQueue.TryRemove(packet.SeqNumber, out i);
            }

            this.ACKQueue.TryAdd(packet.SeqNumber, packet.SeqNumber);
            this.ReceivedWindow.TryAdd(packet.SeqNumber, packet.SeqNumber);

            int diff = packet.SeqNumber - this.LastSeqNumber;

            if (diff != 1)
            {
                for (int i = 0; i < diff; ++i)
                {
                    if (!this.ReceivedWindow.ContainsKey(packet.SeqNumber - i))
                    {
                        if (!this.NACKQueue.ContainsKey(packet.SeqNumber - i))
                        {
                            this.NACKQueue.TryAdd(packet.SeqNumber - i, packet.SeqNumber - i);
                        }
                    }
                }
            }

            if (diff >= 1)
            {
                this.LastSeqNumber = packet.SeqNumber;
                this.WindowStart += diff;
                this.WindowEnd += diff;
            }

            for (int i = 0; i < packet.Packets.Length; ++i)
            {
                if (packet.Packets[i] is EncapsulatedPacket)
                {
                    this.HandleEncapsulatedPacket((EncapsulatedPacket) packet.Packets[i]);
                }
            }
        }

        public void HandleEncapsulatedPacket(EncapsulatedPacket packet)
        {
            if (packet.MessageIndex != -1)
            {
                if (packet.MessageIndex < this.ReliableWindowStart || packet.MessageIndex > this.ReliableWindowEnd || this.ReliableWindow.ContainsKey(packet.MessageIndex))
                {
                    return;
                }

                this.ReliableWindow[packet.MessageIndex] = true;

                if (packet.MessageIndex == this.ReliableWindowStart)
                {

                    for (; this.ReliableWindow.ContainsKey(this.ReliableWindowStart); ++this.ReliableWindowStart)
                    {
                        bool v;
                        this.ReliableWindow.TryRemove(this.ReliableWindowStart, out v);

                        this.ReliableWindowEnd++;
                    }
                }

                if (packet.HasSplit && (packet = this.HandleSplit(packet)) == null)
                {
                    return;
                }

                //TODO: Ordered & Sequenced
                this.HandleEncapsulatedPacketRoute(packet);
            }
        }

        public void HandleEncapsulatedPacketRoute(EncapsulatedPacket packet)
        {
            if (this.Manager == null)
            {
                return;
            }

            int id = packet.Buffer[0];
            RakNetPacket pk = this.Manager.GetPacket(id, packet.Buffer);
            if (id < 0x86 && pk != null)
            {
                if (this.State == SessionState.Connecting)
                {
                    if (id == RakNetConstant.ClientConnectDataPacket)
                    {
                        ClientConnectDataPacket ccd = (ClientConnectDataPacket) pk;
                        ServerHandShakeDataPacket shd = (ServerHandShakeDataPacket) this.Manager.GetPacket(RakNetConstant.ServerHandShakeDataPacket);
                        shd.EndPoint = this.EndPoint;
                        shd.SendPing = ccd.SendPing;
                        shd.SendPong = ccd.SendPing + 1000;

                        this.QueueConnectedPacket(shd, RakNetReliability.UNRELIABLE, 0, RakNetConstant.FlagImmediate);
                    }
                    else if (id == RakNetConstant.ClientHandShakeDataPacket)
                    {
                        ClientHandShakeDataPacket chsd = (ClientHandShakeDataPacket) pk;

                        OutLog.Info(chsd.EndPoint.Port == Server.Instance.EndPoint.Port);
                        if (chsd.EndPoint.Port == Server.Instance.EndPoint.Port)
                        {
                            this.State = SessionState.Connected;
                        }
                    }
                }
                else if (id == RakNetConstant.ClientDisconnectDataPacket)
                {
                    this.Disconnect("clientDisconnect");
                }
                else if (id == RakNetConstant.OnlinePing)
                {
                    OnlinePing ping = (OnlinePing) pk;
                    OnlinePong pong = (OnlinePong) this.Manager.GetPacket(RakNetConstant.OnlinePong);
                    pong.PingID = ping.PingID;

                    this.QueueConnectedPacket(pong, RakNetReliability.UNRELIABLE, 0, RakNetConstant.FlagImmediate);
                }
                else if (id == RakNetConstant.OnlinePong)
                {
                    //TODO: 
                }
            }
            else if (this.State == SessionState.Connected)
            {
                if (id == RakNetConstant.BatchPacket)
                {
                    OutLog.Info("Batch");
                }
            }
        }

        //TODO: Dead Code Fix
        public EncapsulatedPacket HandleSplit(EncapsulatedPacket packet)
        {
            if (!SplitPackets.ContainsKey(packet.SplitID))
            {
                SplitPackets.Add(packet.SplitID, new Dictionary<int, EncapsulatedPacket>());
                if (!SplitPackets[packet.SplitID].ContainsKey(packet.SplitIndex))
                {
                    SplitPackets[packet.SplitID].Add(packet.SplitIndex, packet);
                }
            }
            else
            {
                if (!SplitPackets[packet.SplitID].ContainsKey(packet.SplitIndex))
                {
                    SplitPackets[packet.SplitID].Add(packet.SplitIndex, packet);
                }
            }

            if (SplitPackets[packet.SplitID].Count == packet.SplitCount)
            {
                EncapsulatedPacket pk = new EncapsulatedPacket();
                int offset = 0;
                pk.Buffer = new byte[0];
                for (int i = 0; i < packet.SplitCount; ++i)
                {
                    EncapsulatedPacket p = SplitPackets[packet.SplitID][i];
                    byte[] buffer = pk.Buffer;
                    Array.Resize(ref buffer, pk.Buffer.Length + p.Buffer.Length);
                    pk.Buffer = buffer;
                    Buffer.BlockCopy(p.Buffer, 0, pk.Buffer, offset, p.Buffer.Length);
                    offset += p.Buffer.Length;
                }

                pk.Length = pk.Buffer.Length;

                SplitPackets.Remove(pk.SplitID);

                return pk;
            }

            return null;
        }

        public void HandleAcknowledgePacket()
        {

        }
        #endregion

        #region Send Packet Method
        public void AddEncapsulatedToQueue(EncapsulatedPacket packet, int flags = RakNetConstant.FlagNormal)
        {
            if (RakNetReliability.IsOrdered(packet.Reliability))
            {
                packet.OrderIndex = this.OrderIndex;
            }
            else if (RakNetReliability.IsSequenced(packet.Reliability))
            {
                packet.OrderIndex = this.OrderIndex;
                packet.MessageIndex = this.MessageIndex++;
            }

            if (packet.GetTotalLength() + 4 > this.MTUSize)
            {
                byte[][] buffers = Binary.SplitBytes(new MemorySpan(packet.Buffer), this.MTUSize - 60);
                int splitID = this.SplitID++ % 65536;
                for (int i = 0; i < buffers.Length; ++i)
                {
                    EncapsulatedPacket pk = new EncapsulatedPacket();
                    pk.SplitID = splitID;
                    pk.HasSplit = true;
                    pk.SplitCount = buffers.Length;
                    pk.Reliability = RakNetReliability.UNRELIABLE;
                    pk.SplitIndex = i;
                    pk.Buffer = buffers[i];
                    if (i > 0)
                    {
                        pk.MessageIndex = this.MessageIndex++;
                    }
                    else
                    {
                        pk.MessageIndex = this.MessageIndex;
                    }

                    this.AddToQueue(pk, flags | RakNetConstant.FlagImmediate);
                }
            }
            else
            {
                if (RakNetReliability.IsReliable(packet.Reliability))
                {
                    packet.MessageIndex = this.MessageIndex++;
                }

                this.AddToQueue(packet, flags);
            }
        }

        public void QueueConnectedPacket(RakNetPacket packet, int reliability, int orderChannel, int flags = RakNetConstant.FlagNormal)
        {
            packet.Encode();

            EncapsulatedPacket pk = new EncapsulatedPacket();
            pk.Reliability = reliability;
            pk.OrderChannel = orderChannel;
            pk.Buffer = packet.ToArray();

            this.AddEncapsulatedToQueue(pk, flags);
        }

        public void AddToQueue(EncapsulatedPacket pk, int flags = RakNetConstant.FlagNormal)
        {
            int length = this.SendQueue.Length;

            if (length + pk.GetTotalLength() > this.MTUSize - 36)//IP header (20 bytes) + UDP header (8 bytes) + RakNet weird (8 bytes) = 36 bytes
            {
                this.SendQueuePacket();
            }

            List<object> list = new List<object>(this.SendQueue.Packets);
            list.Add(pk);
            this.SendQueue.Packets = list.ToArray();

            if (flags == RakNetConstant.FlagImmediate)
            {
                this.SendQueuePacket();
            }
        }

        public void SendQueuePacket()
        {
            if (this.SendQueue.Packets?.Length > 0)
            {
                this.SendDatagram(this.SendQueue);
                this.SendQueue = new DataPacket4();
            }
        }

        public void SendDatagram(DataPacket pk)
        {
            if (pk.SeqNumber != -1)
            {
                //this.RecoveryQueue.Remove(pk.SeqNumber);
            }

            pk.SeqNumber = this.LastSeqNumber++;
            //this.RecoveryQueue[pk.SeqNumber] = pk;
            this.SendPacket(pk);

        }

        public void SendPacket(RakNetPacket pk)
        {
            this.Manager.Send(this.EndPoint, pk);
        }
        #endregion

        #region Close Session
        public void Disconnect(string reason)
        {
            this.State = SessionState.Disconnecting;
            OutLog.Info("%server.network.raknet.sessionDisconnect", this.EndPoint, reason);

            this.Close();
        }

        public void Close()
        {
            if (this.State != SessionState.Disconnected)
            {
                this.State = SessionState.Disconnected;

                OutLog.Log("%server.network.raknet.sessionClose", this.EndPoint);
                this.Manager?.RemoveSession(this.EndPoint);
                this.Manager = null;
            }
        }
        #endregion
    }
}
