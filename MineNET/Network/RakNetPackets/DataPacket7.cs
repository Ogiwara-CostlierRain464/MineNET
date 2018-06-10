namespace MineNET.Network.RakNetPackets
{
    public class DataPacket7 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacket7;
    }
}
