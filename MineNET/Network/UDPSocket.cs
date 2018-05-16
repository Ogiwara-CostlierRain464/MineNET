using System.Net;
using System.Net.Sockets;

namespace MineNET.Network
{
    public sealed class UDPSocket : INetworkSocket
    {
        private UdpClient client;
        public UdpClient Socket
        {
            get
            {
                return this.client;
            }
        }

        public UDPSocket(IPEndPoint point)
        {
            this.client = new UdpClient(point);
        }
    }
}
