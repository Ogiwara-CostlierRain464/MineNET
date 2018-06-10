namespace MineNET.Events.ServerEvents
{
    public class ServerCommandEventArgs : ServerEventArgs, ICancelable
    {
        public string Command { get; set; }
        public bool IsCancel { get; set; }

        public ServerCommandEventArgs(string command)
        {
            this.Server = Server.Instance;
            this.Command = command;
        }
    }
}
