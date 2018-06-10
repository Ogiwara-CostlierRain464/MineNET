namespace MineNET.Network.RakNetPackets
{
    public class DataPacket1 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacket1;
    }
}
