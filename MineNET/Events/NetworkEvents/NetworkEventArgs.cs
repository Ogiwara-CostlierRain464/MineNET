using MineNET.Network;
using System;

namespace MineNET.Events.NetworkEvents
{
    public abstract class NetworkEventArgs : EventArgs
    {
        public NetworkManager Network { get; protected set; }
    }
}
