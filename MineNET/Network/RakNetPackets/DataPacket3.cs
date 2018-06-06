namespace MineNET.Network.RakNetPackets
{
    public class DataPacket3 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetConstant.DataPacket3;
    }
}
