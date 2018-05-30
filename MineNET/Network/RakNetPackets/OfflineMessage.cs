using System.Linq;

namespace MineNET.Network.RakNetPackets
{
    public abstract class OfflineMessage : RakNetPacket
    {
        public byte[] Magic { get; private set; }
        public void ReadMagic()
        {
            this.Magic = this.ReadBytes(RakNetConstant.Magic.Length);
        }

        public void WriteMagic()
        {
            this.WriteBytes(RakNetConstant.Magic);
        }

        public bool IsValid()
        {
            return this.Magic.SequenceEqual(RakNetConstant.Magic);
        }
    }
}
