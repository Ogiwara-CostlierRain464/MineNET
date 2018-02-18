﻿using MineNET.Data;
using MineNET.Entities;
using MineNET.Items;
using MineNET.Values;

namespace MineNET.Utils
{
    public class MCBEBinary : BinaryStream
    {
        public Vector2 ReadVector2()
        {
            return new Vector2(this.ReadLFloat(), this.ReadLFloat());
        }

        public void WriteVector2(Vector2 value)
        {
            this.WriteFloat(value.X);
            this.WriteFloat(value.Y);
        }

        public Vector3 ReadVector3()
        {
            return new Vector3(this.ReadLFloat(), this.ReadLFloat(), this.ReadLFloat());
        }

        public void WriteVector3(Vector3 value)
        {
            this.WriteFloat(value.X);
            this.WriteFloat(value.Y);
            this.WriteFloat(value.Z);
        }

        //TODO : ReadBlockPosition

        public void WriteBlockPosition(int x, int y, int z)
        {
            this.WriteSVarInt(x);
            this.WriteUVarInt((uint) y);
            this.WriteSVarInt(z);
        }

        public long ReadEntityUniqueId()
        {
            return this.ReadSVarLong();
        }

        public void WriteEntityUniqueId(long eid)
        {
            this.WriteSVarLong(eid);
        }

        public long ReadEntityRuntimeId()
        {
            return (long) this.ReadUVarLong();
        }

        public void WriteEntityRuntimeId(long eid)
        {
            this.WriteUVarLong((ulong) eid);
        }

        public void WriteAttributes(params EntityAttribute[] attributes)
        {
            this.WriteUVarInt((uint) attributes.Length);
            for (int i = 0; i < attributes.Length; ++i)
            {
                this.WriteLFloat(attributes[i].MinValue);
                this.WriteLFloat(attributes[i].MaxValue);
                this.WriteLFloat(attributes[i].Value);
                this.WriteLFloat(attributes[i].DefaultValue);
                this.WriteString(attributes[i].Name);
            }
        }

        public Skin ReadSkin()
        {
            return new Skin(this.ReadString(), this.ReadString(), this.ReadString(), this.ReadString(), this.ReadString());
        }

        public void WriteSkin(Skin skin)
        {
            this.WriteString(skin.SkinId);
            this.WriteString(skin.SkinData);
            this.WriteString(skin.CapeData);
            this.WriteString(skin.GeometryName);
            this.WriteString(skin.GeometryData);
        }

        public Item ReadItem()
        {
            int id = this.ReadVarInt();
            if (id < 0)
            {
                return Item.Get(0, 0, 0);
            }
            int auxValue = this.ReadVarInt();
            int data = auxValue >> 8;
            if (data == short.MaxValue)
            {
                data = -1;
            }
            int cnt = auxValue & 0xff;

            int nbtLen = this.ReadLShort();
            byte[] nbt = new byte[0];
            if (nbtLen > 0)
            {
                nbt = this.ReadBytes(nbtLen);
            }

            //TODO
            int canPlaceOn = this.ReadVarInt();
            if (canPlaceOn > 0)
            {
                for (int i = 0; i < canPlaceOn; ++i)
                {
                    this.ReadString();
                }
            }

            //TODO
            int canDestroy = this.ReadVarInt();
            if (canDestroy > 0)
            {
                for (int i = 0; i < canDestroy; ++i)
                {
                    this.ReadString();
                }
            }
            return Item.Get(id, (short) data, (byte) cnt, nbt);
        }

        public void WriteItem(Item item)
        {
            if (item == null || item.ItemID == 0)
            {
                this.WriteVarInt(0);
                return;
            }
            this.WriteVarInt(item.ItemID);
            int auxValue = (((item.Damage != 0 ? item.Damage : -1) & 0x7fff) << 8) | item.Count;
            this.WriteVarInt(auxValue);
            byte[] nbt = item.Tag;
            this.WriteLShort((ushort) nbt.Length);
            this.WriteBytes(nbt);
            this.WriteVarInt(0); //TODO
            this.WriteVarInt(0); //TODO
        }
    }
}