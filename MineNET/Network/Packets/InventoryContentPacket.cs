﻿using MineNET.Items;

namespace MineNET.Network.Packets
{
    public class InventoryContentPacket : DataPacket
    {
        public const int ID = ProtocolInfo.INVENTORY_CONTENT_PACKET;

        public override byte PacketID
        {
            get
            {
                return InventoryContentPacket.ID;
            }
        }

        public uint InventoryId { get; set; }

        public Item[] Items { get; set; }

        public override void Encode()
        {
            base.Encode();

            this.WriteUVarInt(this.InventoryId);
            this.WriteUVarInt((uint) this.Items.Length);
            for (int i = 0; i < this.Items.Length; ++i)
            {
                this.WriteItem(this.Items[i]);
            }
        }
    }
}
