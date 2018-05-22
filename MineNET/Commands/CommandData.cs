namespace MineNET.Commands
{
    public class CommandData
    {
        public CommandSender Sender { get; }
        public string Command { get; }

        public CommandData(CommandSender sender, string command)
        {
            this.Sender = sender;
            this.Command = command;
        }
    }
}
