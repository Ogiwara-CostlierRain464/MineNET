namespace MineNET.Network.RakNetPackets
{
    public class DataPacket2 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetConstant.DataPacket2;
    }
}
