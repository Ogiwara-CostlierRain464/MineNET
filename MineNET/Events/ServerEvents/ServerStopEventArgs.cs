namespace MineNET.Events.ServerEvents
{
    public class ServerStopEventArgs : ServerEventArgs
    {
        public bool IsValid { get; }

        public ServerStopEventArgs(Server server, bool isValid)
        {
            this.Server = server;
            this.IsValid = isValid;
        }
    }
}
