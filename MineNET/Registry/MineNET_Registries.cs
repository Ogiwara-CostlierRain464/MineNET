using MineNET.Registry;

namespace MineNET
{
    public static class MineNET_Registries
    {
        //BlockEntity
        //Block
        public static CommandRegistry Command { get; } = new CommandRegistry();
        public static EntityRegistry Entity { get; } = new EntityRegistry();
        //Item
        public static RakNetPacketRegistry RakNetPacket { get; } = new RakNetPacketRegistry();
        public static MinecraftPacketRegistry MinecraftPacket { get; } = new MinecraftPacketRegistry();

    }
}
