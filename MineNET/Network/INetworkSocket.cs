using System;
using System.Net;
using System.Net.Sockets;

namespace MineNET.Network
{
    public interface INetworkSocket : IDisposable
    {
        IPEndPoint EndPoint { get; }
        UdpClient Socket { get; }
    }
}
