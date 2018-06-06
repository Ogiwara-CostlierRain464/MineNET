namespace MineNET.Network.RakNetPackets
{
    public class DataPacket8 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetConstant.DataPacket8;
    }
}
