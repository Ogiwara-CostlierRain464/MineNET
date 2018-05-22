namespace MineNET.Events.ServerEvents
{
    public class ServerStartEventArgs : ServerEventArgs
    {
        public bool IsValid { get; }

        public ServerStartEventArgs(Server server, bool isValid)
        {
            this.Server = server;
            this.IsValid = isValid;
        }
    }
}
