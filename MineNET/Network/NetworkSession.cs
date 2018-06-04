using System.Net;

namespace MineNET.Network
{
    public class NetworkSession
    {
        public IPEndPoint EndPoint { get; }
        public long ClientID { get; }
        public short MTUSize { get; }

        public NetworkSession(IPEndPoint endPoint, long clientID, short mtuSize)
        {
            this.EndPoint = endPoint;
            this.ClientID = clientID;
            this.MTUSize = mtuSize;
        }
    }
}
