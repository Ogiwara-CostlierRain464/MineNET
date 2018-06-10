namespace MineNET.Network.RakNetPackets
{
    public class DataPacketA : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacketA;
    }
}
