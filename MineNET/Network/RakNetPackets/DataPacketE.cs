namespace MineNET.Network.RakNetPackets
{
    public class DataPacketE : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacketE;
    }
}
