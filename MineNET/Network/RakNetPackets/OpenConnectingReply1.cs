﻿namespace MineNET.Network.RakNetPackets
{
    public class OpenConnectingReply1 : OfflineMessage
    {
        public override byte MessageID { get; protected set; } = RakNetConstant.OpenConnectingReply1;

        public long ServerID { get; set; }
        public short MTUSize { get; set; }

        public override void Encode()
        {
            base.Encode();

            this.WriteMagic();
            this.WriteLong(this.ServerID);
            this.WriteByte(0);
            this.WriteShort(this.MTUSize);
        }
    }
}