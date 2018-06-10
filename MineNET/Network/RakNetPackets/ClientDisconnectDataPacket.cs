namespace MineNET.Network.RakNetPackets
{
    public class ClientDisconnectDataPacket : RakNetPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.ClientDisconnectDataPacket;
    }
}
