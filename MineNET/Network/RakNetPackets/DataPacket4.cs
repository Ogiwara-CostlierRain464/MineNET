namespace MineNET.Network.RakNetPackets
{
    public class DataPacket4 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetConstant.DataPacket4;
    }
}
