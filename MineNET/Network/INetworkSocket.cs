using System.Net.Sockets;

namespace MineNET.Network
{
    public interface INetworkSocket
    {
        UdpClient Socket { get; }
    }
}
