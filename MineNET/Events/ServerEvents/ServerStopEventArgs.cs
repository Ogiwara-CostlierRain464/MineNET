using System;

namespace MineNET.Events.ServerEvents
{
    public class ServerStopEventArgs : EventArgs
    {
        public Server Server { get; }
        public bool IsValid { get; }

        public ServerStopEventArgs(Server server, bool isValid)
        {
            this.Server = server;
            this.IsValid = isValid;
        }
    }
}
