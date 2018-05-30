namespace MineNET.Network.RakNetPackets
{
    public static class RakNetConstant
    {
        public static readonly byte[] Magic = new byte[]

        {

            0x00,

            0xff,

            0xff,

            0x00,

            0xfe,

            0xfe,

            0xfe,

            0xfe,

            0xfd,

            0xfd,

            0xfd,

            0xfd,

            0x12,

            0x34,

            0x56,

            0x78

        };

        public const byte OfflinePing = 0x01;
        public const byte OfflinePong = 0x1c;
    }
}
