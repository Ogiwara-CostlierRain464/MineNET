namespace MineNET.Events.ServerEvents
{
    public class ServerCommandEventArgs : ServerEventArgs, ICancelable
    {
        public string Command { get; set; }
        public bool IsCancel { get; set; }
        public ServerCommandEventArgs(Server server, string command)
        {
            this.Server = server;
            this.Command = command;
        }
    }
}
