using MineNET.Plugins;
using System;

namespace MineNET.TestPlugin
{
    public class TestPlugin : PluginBase
    {
        public override string Name
        {
            get
            {
                return "MineNET_TestPlugin";
            }
        }

        public override string Description
        {
            get
            {
                return "MineNET Test Plugin.";
            }
        }

        public override void OnDisable()
        {
            OutLog.Info("Goodbye MineNET plugin!");
        }

        public override void OnEnable()
        {
            OutLog.Info("Hello MineNET plugin!");
            Server.Instance.Event.Server.ServerCommand += Server_ServerCommand;
        }

        private void Server_ServerCommand(object sender, Events.ServerEvents.ServerCommandEventArgs e)
        {
            if (e.CommandData.Command == "test")
            {
                OutLog.Info("Test Command!");
            }
        }

        public override void OnError(Exception e)
        {

        }

        public override void OnLoad()
        {
            OutLog.Info("Good morning MineNET plugin!");
        }
    }
}
