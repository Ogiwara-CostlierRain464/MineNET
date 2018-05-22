﻿using System;
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
