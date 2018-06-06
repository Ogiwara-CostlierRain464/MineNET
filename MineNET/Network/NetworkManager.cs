using MineNET.Network.RakNetPackets;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MineNET.Network
{
    public sealed class NetworkManager : IDisposable
    {
        #region Property & Field
        public UdpClient Client { get; private set; }

        public Thread ReceiveThread { get; private set; }
        public Thread UpdateThread { get; private set; }

        public bool IsRunNetwork { get; private set; }

        public long ServerID { get; } = MineNET.Utils.Random.CreateRandomID();

        public ConcurrentDictionary<string, NetworkSession> Sessions { get; } = new ConcurrentDictionary<string, NetworkSession>();
        #endregion

        #region Ctor
        public NetworkManager()
        {
            this.Init();
        }
        #endregion

        #region Init Method
        private void Init()
        {
            UdpClient client = Server.Instance.NetworkSocket.Socket;
            client.DontFragment = false;
            client.EnableBroadcast = false;
            this.Client = client;

            this.RegisterPackets();

            this.IsRunNetwork = true;

            this.ReceiveThread = new Thread(this.ReceiveClock);
            this.ReceiveThread.Name = "PacketThread";
            this.ReceiveThread.Start();

            this.UpdateThread = new Thread(this.OnUpdate);
            this.UpdateThread.Name = "SessionUpdateThread";
            this.UpdateThread.Start();
        }

        private void RegisterPackets()
        {
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.OfflinePing, new OfflinePing());

            MineNET_Registries.RakNetPacket.Add(RakNetConstant.OpenConnectingRequest1, new OpenConnectingRequest1());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.OpenConnectingReply1, new OpenConnectingReply1());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.OpenConnectingRequest2, new OpenConnectingRequest2());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.OpenConnectingReply2, new OpenConnectingReply2());

            MineNET_Registries.RakNetPacket.Add(RakNetConstant.OfflinePong, new OfflinePong());

            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket0, new DataPacket0());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket1, new DataPacket1());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket2, new DataPacket2());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket3, new DataPacket3());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket4, new DataPacket4());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket5, new DataPacket5());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket6, new DataPacket6());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket7, new DataPacket7());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket8, new DataPacket8());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacket9, new DataPacket9());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacketA, new DataPacketA());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacketB, new DataPacketB());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacketC, new DataPacketC());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacketD, new DataPacketD());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacketE, new DataPacketE());
            MineNET_Registries.RakNetPacket.Add(RakNetConstant.DataPacketF, new DataPacketF());
        }
        #endregion

        #region Thread Method
        private void ReceiveClock()
        {
            while (IsRunNetwork)
            {
                this.ReceiveUpdate();
            }
        }

        private void ReceiveUpdate()
        {
            try
            {
                if (this.IsRunNetwork)
                {
                    IPEndPoint point = null;
                    byte[] bytes = this.Client.Receive(ref point);

                    this.HandleRakNetPacket(point, bytes);
                }
            }
            catch (Exception e)
            {
                OutLog.Notice(e);
            }
        }

        public void OnUpdate()
        {
            while (IsRunNetwork)
            {
                foreach (KeyValuePair<string, NetworkSession> session in this.Sessions)
                {
                    session.Value.OnUpdate();
                }
                Thread.Sleep(1);
            }
        }
        #endregion

        #region Packet Handle Method
        private void HandleRakNetPacket(IPEndPoint endPoint, byte[] bytes)
        {
            if (bytes?.Length != 0)
            {
                byte msgId = bytes[0];
                RakNetPacket pk = this.GetPacket(msgId, bytes);
                if (pk != null)
                {
                    if (pk is OfflineMessage)
                    {
                        if (this.SessionCreated(endPoint))
                        {
                            OutLog.Log("%server.network.raknet.sessionCreated", endPoint);
                            return;
                        }

                        this.HandleOfflineMessage(endPoint, (OfflineMessage) pk);
                        pk.Dispose();
                        return;
                    }

                    if (!this.SessionCreated(endPoint))
                    {
                        OutLog.Log("%server.network.raknet.sessionNotCreated", endPoint);
                        return;
                    }

                    if (pk is DataPacket)
                    {
                        NetworkSession session = this.GetSession(endPoint);
                        session.HandleDataPacket((DataPacket) pk);
                        pk.Dispose();
                        return;
                    }
                }

                OutLog.Log("%server.network.raknet.notHandle", msgId);
            }
        }

        private void HandleOfflineMessage(IPEndPoint endPoint, OfflineMessage msg)
        {
            if (msg.MessageID == RakNetConstant.OfflinePing)
            {
                OfflinePing ping = (OfflinePing) msg;
                OfflinePong pong = (OfflinePong) this.GetPacket(RakNetConstant.OfflinePong);
                pong.Ping = ping.Ping;
                pong.ServerID = this.ServerID;
                pong.ServerName = "MCPE;MineNET;261;1.4.2;0;20;MineNET;Survival";

                this.Send(endPoint, pong);
            }
            else if (msg.MessageID == RakNetConstant.OpenConnectingRequest1)
            {
                OpenConnectingRequest1 req1 = (OpenConnectingRequest1) msg;
                OpenConnectingReply1 rep1 = (OpenConnectingReply1) this.GetPacket(RakNetConstant.OpenConnectingReply1);
                rep1.ServerID = this.ServerID;
                rep1.MTUSize = req1.MTUSize;

                this.Send(endPoint, rep1);
            }
            else if (msg.MessageID == RakNetConstant.OpenConnectingRequest2)
            {
                OpenConnectingRequest2 req2 = (OpenConnectingRequest2) msg;
                OpenConnectingReply2 rep2 = (OpenConnectingReply2) this.GetPacket(RakNetConstant.OpenConnectingReply2);
                rep2.ServerID = this.ServerID;
                rep2.EndPoint = req2.EndPoint;
                rep2.MTUSize = req2.MTUSize;

                if (req2.EndPoint.Port == Server.Instance.NetworkSocket.EndPoint.Port)
                {
                    this.SessionCreate(endPoint, req2.ClientID, req2.MTUSize);
                }

                this.Send(endPoint, rep2);
            }
        }
        #endregion

        #region Session Method
        public void SessionCreate(IPEndPoint endPoint, long clientID, short mtuSize)
        {
            if (!this.SessionCreated(endPoint))
            {
                this.Sessions.TryAdd(endPoint.ToString(), new NetworkSession(endPoint, clientID, mtuSize));
                OutLog.Info("%server.network.raknet.sessionCreate", endPoint, mtuSize);
            }
        }

        public bool SessionCreated(IPEndPoint endPoint)
        {
            if (this.Sessions.ContainsKey(endPoint.ToString()))
            {
                return true;
            }

            return false;
        }

        public NetworkSession GetSession(IPEndPoint endPoint)
        {
            string endPointStr = endPoint.ToString();
            if (this.Sessions.ContainsKey(endPointStr))
            {
                return this.Sessions[endPointStr];
            }

            return null;
        }

        public void RemoveSession(IPEndPoint endPoint)
        {
            string endPointStr = endPoint.ToString();
            if (this.Sessions.ContainsKey(endPointStr))
            {
                NetworkSession session;
                this.Sessions[endPointStr].Close();
                this.Sessions.TryRemove(endPointStr, out session);
            }
        }
        #endregion

        #region Get Registry Packet Method
        private RakNetPacket GetPacket(int msgId, byte[] buffer = null)
        {
            RakNetPacket pk = null;
            MineNET_Registries.RakNetPacket.TryGetValue(msgId, out pk);

            if (pk != null && buffer != null)
            {
                pk.SetBuffer(buffer);
                pk.Decode();
            }

            return pk;
        }
        #endregion

        #region Send Message Method
        public void Send(IPEndPoint point, RakNetPacket msg)
        {
            msg.Encode();
            byte[] buffer = msg.ToArray();
            this.Client.Send(buffer, buffer.Length, point);
        }
        #endregion

        #region Dispose Method
        public void Dispose()
        {
            this.IsRunNetwork = false;
            this.ReceiveThread.Abort();
            this.ReceiveThread = null;
        }
        #endregion
    }
}
