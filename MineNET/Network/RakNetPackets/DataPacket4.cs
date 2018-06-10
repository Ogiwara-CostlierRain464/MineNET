namespace MineNET.Network.RakNetPackets
{
    public class DataPacket4 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacket4;
    }
}
