namespace MineNET.Network.RakNetPackets
{
    public class DataPacketB : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetConstant.DataPacketB;
    }
}
