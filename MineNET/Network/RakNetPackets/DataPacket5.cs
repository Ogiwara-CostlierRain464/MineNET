﻿namespace MineNET.Network.RakNetPackets
{
    public class DataPacket5 : DataPacket
    {
        public override byte MessageID { get; protected set; } = RakNetProtocol.DataPacket5;
    }
}
