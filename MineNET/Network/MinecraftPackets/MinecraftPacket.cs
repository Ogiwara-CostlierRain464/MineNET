using MineNET.Utils;

namespace MineNET.Network.MinecraftPackets
{
    public abstract class MinecraftPacket : BinaryStream, ICloneable<MinecraftPacket>
    {
        public abstract byte PacketID { get; protected set; }

        public byte Extra1 { get; set; }
        public byte Extra2 { get; set; }

        public virtual void Encode()
        {
            this.WriteByte(this.PacketID);
            this.WriteByte(this.Extra1);
            this.WriteByte(this.Extra2);
        }

        public virtual void Decode()
        {
            this.ReadByte();
            this.Extra1 = this.ReadByte();
            this.Extra2 = this.ReadByte();
        }

        public new MinecraftPacket Clone()
        {
            return (MinecraftPacket) this.MemberwiseClone();
        }
    }
}
