namespace MineNET.Network.RakNetPackets
{
    public class DataPacket0 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetConstant.DataPacket0;
    }
}
