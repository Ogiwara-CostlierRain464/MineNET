using MineNET.Network.RakNetPackets;
using System.Collections.Generic;
using System.Net;

namespace MineNET.Network
{
    public class NetworkSession
    {
        #region Const
        public const int ChannelCount = 32;
        #endregion

        #region Static Property
        public static int WindowSize { get; private set; } = 2048;
        #endregion

        #region Property & Field
        public IPEndPoint EndPoint { get; }
        public long ClientID { get; }
        public short MTUSize { get; }

        public NetworkManager Manager { get; }

        public int MessageIndex { get; private set; }

        public List<int> SendOrderedIndex { get; private set; } = new List<int>();
        public List<int> SendSequencedIndex { get; private set; } = new List<int>();

        public List<int> ReceiveOrderedIndex { get; private set; } = new List<int>();
        public List<int> ReceiveSequencedHighestIndex { get; private set; } = new List<int>();
        public List<EncapsulatedPacket[]> ReceiveOrderedPackets { get; private set; } = new List<EncapsulatedPacket[]>();

        public int SplitID { get; private set; }

        public int SendSeqNumber { get; private set; }

        public int LastUpdateTime { get; private set; }
        public int DisconnectionTime { get; private set; }

        public bool IsTemporal { get; private set; } = true;

        public List<DataPacket> PacketToSend { get; private set; } = new List<DataPacket>();
        public bool IsActive { get; private set; }

        public List<int> ACKQueue { get; private set; } = new List<int>();
        public List<int> NACKQueue { get; private set; } = new List<int>();

        public List<DataPacket> RecoveryQueue { get; private set; } = new List<DataPacket>();

        public List<DataPacket[]> SplitPackets { get; private set; } = new List<DataPacket[]>();

        public List<int[]> NeedACK { get; private set; } = new List<int[]>();

        public DataPacket SendQueue { get; private set; }

        public int WindowStart { get; set; }
        public int WindowEnd { get; set; }
        public int HighestSeqNumberThisTick { get; private set; } = -1;

        public int ReliableWindowStart { get; private set; }
        public int ReliableWindowEnd { get; private set; }
        public List<bool> ReliableWindow { get; private set; } = new List<bool>();

        public int LastPingTime { get; private set; } = -1;
        public int LastPingMeasure { get; private set; } = 1;

        public SessionState State { get; private set; } = SessionState.Connecting;
        #endregion

        #region Ctor Method
        public NetworkSession(IPEndPoint endPoint, long clientID, short mtuSize)
        {
            this.Manager = Server.Instance.Network;

            this.EndPoint = endPoint;
            this.ClientID = clientID;
            this.MTUSize = mtuSize;

            this.LastPingTime = 0;
            this.WindowStart = 0;
            this.WindowEnd = NetworkSession.WindowSize;

            this.ReliableWindowStart = 0;
            this.ReliableWindowEnd = NetworkSession.WindowSize;

            List<int> initArray = new List<int>();
            for (int i = 0; i < NetworkSession.ChannelCount; ++i)
            {
                initArray.Add(0);
            }

            this.SendOrderedIndex.AddRange(initArray);
            this.SendSequencedIndex.AddRange(initArray);
            this.ReceiveOrderedIndex.AddRange(initArray);
            this.ReceiveSequencedHighestIndex.AddRange(initArray);

            for (int i = 0; i < NetworkSession.ChannelCount; ++i)
            {
                this.ReceiveOrderedPackets.Add(new EncapsulatedPacket[0]);
            }
        }
        #endregion

        #region Update Method
        public void OnUpdate()
        {
            if (!this.IsActive && this.LastUpdateTime >= 500)
            {
                //disconnect
                return;
            }

            //if (this.State == SessionState.Connecting &&
            //    (this.ACKQueue.Count == 0))
        }
        #endregion

        #region Handle Packet Method
        public void HandleDataPacket(DataPacket packet)
        {
            packet.Decode();
        }

        public void HandleEncapsulatedPacket(EncapsulatedPacket packet)
        {

        }

        public void HandleAcknowledgePacket()
        {

        }

        public void HandleOnlinePing()
        {

        }
        #endregion
    }
}
