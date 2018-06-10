﻿using System;

namespace MineNET.Events.NetworkEvents
{
    public sealed class NetworkEvent
    {
        public event EventHandler<NetworkPacketReceiveEventArgs> NetworkPacketReceive;
        internal void OnNetworkPacketReceive(object sender, NetworkPacketReceiveEventArgs e)
        {
            this.NetworkPacketReceive?.Invoke(sender, e);
        }

        public event EventHandler<NetworkCreateSessionEventArgs> NetworkCreateSession;
        internal void OnNetworkCreateSession(object sender, NetworkCreateSessionEventArgs e)
        {
            this.NetworkCreateSession?.Invoke(sender, e);
        }
    }
}
