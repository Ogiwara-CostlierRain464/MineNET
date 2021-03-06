﻿using MineNET.Values;

namespace MineNET.Network.Packets
{
    public class ContainerOpenPacket : DataPacket
    {
        public const int ID = ProtocolInfo.CONTAINER_OPEN_PACKET;

        public override byte PacketID
        {
            get
            {
                return ContainerOpenPacket.ID;
            }
        }

        public byte WindowId { get; set; }

        public byte Type { get; set; }

        public Vector3 Position { get; set; }

        public long EntityUniqueId { get; set; } = -1;

        public override void Encode()
        {
            base.Encode();

            this.WriteByte(this.WindowId);
            this.WriteByte(this.Type);
            this.WriteBlockVector3(this.Position);
            this.WriteEntityUniqueId(this.EntityUniqueId);
        }
    }
}
