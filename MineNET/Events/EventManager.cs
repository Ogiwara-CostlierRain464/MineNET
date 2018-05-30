using MineNET.Events.IOEvents;
using MineNET.Events.PlayerEvents;
using MineNET.Events.ServerEvents;

namespace MineNET.Events
{
    public sealed class EventManager
    {
        public IOEvent IO { get; }
        public PlayerEvent Player { get; }
        public ServerEvent Server { get; }

        public EventManager()
        {
            this.IO = new IOEvent();
            this.Player = new PlayerEvent();
            this.Server = new ServerEvent();
        }
    }
}
