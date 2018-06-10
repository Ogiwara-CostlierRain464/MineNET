namespace MineNET.Network.RakNetPackets
{
    public class DataPacketD : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacketD;
    }
}
