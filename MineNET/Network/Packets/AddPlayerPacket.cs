﻿using MineNET.Data;
using MineNET.Entities.Metadata;
using MineNET.Items;
using MineNET.Values;

namespace MineNET.Network.Packets
{
    public class AddPlayerPacket : DataPacket
    {
        public const int ID = ProtocolInfo.ADD_PLAYER_PACKET;

        public override byte PacketID
        {
            get
            {
                return AddPlayerPacket.ID;
            }
        }

        public UUID Uuid { get; set; }
        public string Username { get; set; }
        public string ThirdPartyName { get; set; } = "";
        public int Platform { get; set; } = 0;
        public long EntityUniqueId { get; set; }
        public long EntityRuntimeId { get; set; }
        public string PlatformChatId { get; set; } = "";
        public Vector3 Position { get; set; }
        public Vector3 Speed { get; set; }
        public Vector3 Direction { get; set; }
        public Item Item { get; set; } = Item.Get(0, 0, 0);
        public EntityMetadataManager Metadata { get; set; } = new EntityMetadataManager();

        public int Flag { get; set; } = 0;
        public int CommandPermission { get; set; } = 0;
        public int ActionPermissions { get; set; } = 0; //TODO:
        public int PermissionLevel { get; set; } = PlayerPermissions.MEMBER.GetIndex();
        public int StoredCustomPermissions { get; set; } = 0;

        public override void Encode()
        {
            base.Encode();

            this.WriteUUID(this.Uuid);
            this.WriteString(this.Username);
            this.WriteString(this.ThirdPartyName);
            this.WriteSVarInt(this.Platform);
            this.WriteEntityUniqueId(this.EntityUniqueId);
            this.WriteEntityRuntimeId(this.EntityRuntimeId);
            this.WriteString(this.PlatformChatId);
            this.WriteVector3(this.Position);
            this.WriteVector3(this.Speed);
            this.WriteVector3(this.Direction);
            this.WriteItem(this.Item);
            this.WriteEntityMetadata(this.Metadata);

            this.WriteVarInt(this.Flag);
            this.WriteVarInt(this.CommandPermission);
            this.WriteVarInt(this.ActionPermissions);
            this.WriteVarInt(this.PermissionLevel);
            this.WriteVarInt(this.StoredCustomPermissions);
            this.WriteLLong(0);

            this.WriteUVarInt(0); //TODO: EntityLink size
            //TODO: WriteEntityLink
        }
    }
}
