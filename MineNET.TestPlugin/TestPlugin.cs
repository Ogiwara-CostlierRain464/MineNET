using MineNET.Plugins;
using System;

namespace MineNET.TestPlugin
{
    public class TestPlugin : IPlugin
    {
        public ApiVersion ApiVersion
        {
            get
            {
                return ApiVersion.Version_1_0_0_0;
            }
        }

        public string Description
        {
            get
            {
                return "MineNET Test Plugin.";
            }
        }

        public PluginFlags Flag
        {
            get
            {
                return PluginFlags.Plugin;
            }
        }

        public string Name
        {
            get
            {
                return "MineNET_TestPlugin";
            }
        }

        public string[] PremisePlugins
        {
            get
            {
                return null;
            }
        }

        public string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }

        public void OnDisable()
        {
            OutLog.Info("Goodbye MineNET plugin!");
        }

        public void OnEnable()
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

        public void OnError(Exception e)
        {

        }

        public void OnLoad()
        {
            OutLog.Info("Good morning MineNET plugin!");
        }
    }
}
