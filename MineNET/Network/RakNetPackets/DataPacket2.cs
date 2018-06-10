namespace MineNET.Network.RakNetPackets
{
    public class DataPacket2 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacket2;
    }
}
