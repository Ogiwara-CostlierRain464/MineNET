namespace MineNET.Network.RakNetPackets
{
    public class DataPacket6 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacket6;
    }
}
