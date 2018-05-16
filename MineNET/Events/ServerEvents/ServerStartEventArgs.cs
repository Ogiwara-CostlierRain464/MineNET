using System;

namespace MineNET.Events.ServerEvents
{
    public class ServerStartEventArgs : EventArgs
    {
        public Server Server { get; }
        public bool IsValid { get; }

        public ServerStartEventArgs(Server server, bool isValid)
        {
            this.Server = server;
            this.IsValid = isValid;
        }
    }
}
