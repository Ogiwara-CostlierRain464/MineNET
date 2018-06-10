using MineNET.Network.RakNetPackets;
using System.Net;

namespace MineNET.Events.NetworkEvents
{
    public class NetworkPacketReceiveEventArgs : NetworkEventArgs, ICancelable
    {
        public IPEndPoint EndPoint { get; }
        public RakNetPacket Packet { get; set; }
        public bool IsCancel { get; set; }

        public NetworkPacketReceiveEventArgs(IPEndPoint endPoint, RakNetPacket packet)
        {
            this.Network = Server.Instance.Network;

            this.EndPoint = endPoint;
            this.Packet = packet;
        }
    }
}
