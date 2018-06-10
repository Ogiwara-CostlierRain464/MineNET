using MineNET.Entities.Players;

namespace MineNET.Events.PlayerEvents
{
    public class PlayerCommandEventArgs : PlayerEventArgs, ICancelable
    {
        public string Command { get; set; }
        public bool IsCancel { get; set; }

        public PlayerCommandEventArgs(Player player, string cmd)
        {
            this.Player = player;
            this.Command = cmd;
        }
    }
}
