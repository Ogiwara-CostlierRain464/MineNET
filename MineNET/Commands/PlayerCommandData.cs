namespace MineNET.Commands
{
    public class PlayerCommandData : CommandData
    {
        public Player SenderPlayer
        {
            get
            {
                return this.Sender as Player;
            }
        }
        public PlayerCommandData(Player sender, string command) : base(sender, command)
        {
        }
    }
}
