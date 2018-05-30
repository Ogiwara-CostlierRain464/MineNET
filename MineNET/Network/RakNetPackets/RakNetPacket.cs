using MineNET.Utils;

namespace MineNET.Network.RakNetPackets
{
    public abstract class RakNetPacket : BinaryStream
    {
        public abstract byte MessageID { get; protected set; }

        public virtual void Encode()
        {
            this.WriteByte(this.MessageID);
        }
        public virtual void Decode()
        {
            this.ReadByte();
        }
    }
}
