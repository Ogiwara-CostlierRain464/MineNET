﻿namespace MineNET.RakNet.Packets
{
    public abstract class OfflineMessage : Packet
    {
        public void WriteMagic()
        {
            this.WriteBytes(RakNetServer.Magic);
        }

        public byte[] ReadMagic()
        {
            return ReadBytes(16);
        }
    }
}
