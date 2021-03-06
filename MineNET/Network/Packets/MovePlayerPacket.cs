﻿using MineNET.Values;

namespace MineNET.Network.Packets
{
    public class MovePlayerPacket : DataPacket
    {
        public const int ID = ProtocolInfo.MOVE_PLAYER_PACKET;

        public const int MODE_NORMAL = 0;
        public const int MODE_RESET = 1;
        public const int MODE_TELEPORT = 2;
        public const int MODE_PITCH = 3; //facepalm Mojang

        public override byte PacketID
        {
            get
            {
                return MovePlayerPacket.ID;
            }
        }

        public long EntityRuntimeId { get; set; }

        public Vector3 Position { get; set; }

        public Vector3 Direction { get; set; }

        public byte Mode { get; set; }

        public bool OnGround { get; set; }

        public long OtherEntityRuntimeId { get; set; }

        public int TeleportCuase { get; set; } = 0;

        public int TeleportItem { get; set; } = 0;

        public override void Encode()
        {
            base.Encode();

            this.WriteUVarLong((ulong) this.EntityRuntimeId);
            this.WriteVector3(this.Position);
            this.WriteVector3(this.Direction);
            this.WriteByte(this.Mode);
            this.WriteBool(this.OnGround);
            this.WriteUVarLong((ulong) this.OtherEntityRuntimeId);
            if (this.Mode == MovePlayerPacket.MODE_TELEPORT)
            {
                this.WriteLInt((uint) this.TeleportCuase);
                this.WriteLInt((uint) this.TeleportItem);
            }
        }

        public override void Decode()
        {
            base.Decode();

            this.EntityRuntimeId = (long) this.ReadUVarLong();
            this.Position = this.ReadVector3();
            this.Direction = this.ReadVector3();
            this.Mode = this.ReadByte();
            this.OnGround = this.ReadBool();
            this.OtherEntityRuntimeId = (long) this.ReadUVarLong();
            if (this.Mode == MovePlayerPacket.MODE_TELEPORT)
            {
                this.TeleportCuase = (int) this.ReadLInt();
                this.TeleportItem = (int) this.ReadLInt();
            }
        }
    }
}
