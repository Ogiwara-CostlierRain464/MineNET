using MineNET.Network.RakNetPackets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MineNET.Network
{
    public sealed class NetworkManager : IDisposable
    {
        #region Property & Field
        public UdpClient Client { get; private set; }

        public Thread ClockThread { get; private set; }

        public bool IsRunNetwork { get; private set; }
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

            this.IsRunNetwork = true;

            this.ClockThread = new Thread(this.ClockGenerator);
            this.ClockThread.Start();
        }
        #endregion

        #region Thread Method
        private void ClockGenerator()
        {
            while (IsRunNetwork)
            {
                this.Update();
            }
        }

        private void Update()
        {
            try
            {
                IPEndPoint point = null;
                byte[] bytes = this.Client.Receive(ref point);

                this.HandlePacket(point, bytes);
            }
            catch (Exception e)
            {
                OutLog.Notice(e);
            }
        }
        #endregion

        #region Packet Handle Method
        private void HandlePacket(IPEndPoint endPoint, byte[] bytes)
        {
            if (bytes?.Length != 0)
            {
                byte msgId = bytes[0];
                if (RakNetConstant.OfflinePing == msgId)
                {
                    OfflinePing ping = new OfflinePing();
                    ping.SetBuffer(bytes);
                    ping.Decode();

                    OfflinePong pong = new OfflinePong();
                    pong.Ping = ping.Ping;
                    pong.ServerID = 5493;
                    pong.ServerName = $"MCPE;Test;261;1.4.2;0;20;MineNET;Survival";

                    this.Send(endPoint, pong);
                }
            }
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
            this.ClockThread.Join();
            this.ClockThread = null;
        }
        #endregion
    }
}
