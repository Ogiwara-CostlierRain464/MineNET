using MineNET.Network.RakNetPackets;
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
                //ack
            }

            if (this.NACKQueue.Count > 0)
            {
                //nack
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

            --this.LastUpdateTime;
        }
        #endregion

        #region Handle Packet Method
        public void HandleDataPacket(DataPacket packet)
        {
            if (packet.SeqNumber < this.WindowStart || packet.SeqNumber > this.WindowEnd || this.ACKQueue.ContainsKey(packet.SeqNumber))
            {
                OutLog.Log("Error");
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

                if (packet.HasSplit && (packet = this.HandleSplit()) == null)
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
            if (id < 0x86)
            {
                if (this.State == SessionState.Connecting)
                {
                    if (id == RakNetConstant.ClientConnectDataPacket)
                    {
                        OutLog.Info("Test1");
                    }
                    else if (id == RakNetConstant.ClientHandShakeDataPacket)
                    {
                        OutLog.Info("Test2");
                    }
                }
                else if (id == RakNetConstant.ClientDisconnectDataPacket)
                {
                    this.Disconnect("clientDisconnect");
                }
                else if (id == RakNetConstant.OnlinePing)
                {

                }
                else if (id == RakNetConstant.OnlinePong)
                {

                }
            }
            else if (this.State == SessionState.Connected)
            {
                if (id == RakNetConstant.BatchPacket)
                {

                }
            }
        }

        //TODO: Dead Code Fix
        public EncapsulatedPacket HandleSplit()
        {
            return null;
        }

        public void HandleAcknowledgePacket()
        {

        }

        public void HandleOnlinePing()
        {

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
