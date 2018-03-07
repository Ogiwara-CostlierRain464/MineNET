﻿using System;
using System.Diagnostics;
using System.Linq;
using MineNET.Commands;
using MineNET.Data;
using MineNET.Entities;
using MineNET.Events.ServerEvents;
using MineNET.Network;
using MineNET.Plugins;
using MineNET.Utils;

namespace MineNET
{
    public sealed partial class Server
    {
        public static Server Instance
        {
            get
            {
                return instance;
            }
        }

        public static MineNETConfig MineNETConfig
        {
            get
            {
                return Instance.mineNETConfig;
            }
        }

        public static ServerConfig ServerConfig
        {
            get
            {
                return Instance.serverConfig;
            }
        }

        public static string ExecutePath
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }

        public NetworkManager NetworkManager
        {
            get
            {
                return this.networkManager;
            }
        }

        public CommandManager CommandManager
        {
            get
            {
                return this.commandManager;
            }
        }

        public PluginManager PluginManager
        {
            get
            {
                return this.pluginManager;
            }
        }

        public Logger Logger
        {
            get
            {
                return this.logger;
            }
        }

        public bool IsShutdown()
        {
            return this.isShutdown;
        }

        public void Start()
        {
            instance = this;

            Stopwatch s = new Stopwatch();
            s.Start();

            Init();

            s.Stop();
            Logger.Info("%server_started");
            Logger.Info("%server_started2", s.Elapsed.ToString());

            ServerEvents.OnServerStart(new ServerStartEventArgs());
        }

        public void Stop()
        {
            Logger.Info("%server_stop");
            this.mineNETConfig.Save<MineNETConfig>();
            this.serverConfig.Save<ServerConfig>();

            Player[] players = this.GetPlayers();
            for (int i = 0; i < players.Length; ++i)
            {
                players[i].Close("disconnect.closed");//TODO: Option Add
            }

            this.NetworkManager.Server.UDPClientClose();

            ServerEvents.OnServerStop(new ServerStopEventArgs());

            this.Kill();
        }

        public void ErrorStop(Exception e)
        {
            this.logger = new Logger();
            Logger.Fatal(e.ToString());
            Logger.Error("%server_stop_error");
            Logger.Info("%server_stop");

            this.mineNETConfig?.Save<MineNETConfig>();
            this.serverConfig?.Save<ServerConfig>();

            Player[] players = this.GetPlayers();
            for (int i = 0; i < players.Length; ++i)
            {
                players[i].Close("disconnect.closed");//TODO: Option Add
            }

            this.NetworkManager.Server.UDPClientClose();

            ServerEvents.OnServerStop(new ServerStopEventArgs());

            this.Kill();
        }

        public void AddPlayerList(Player sender, PlayerListEntry entry)
        {
            if (!this.playerListEntries.Contains(entry))
            {
                this.playerListEntries.Add(entry);
                this.SendAddPlayerLists(sender);
            }
        }

        public void RemovePlayerList(string name)
        {
            Player player = this.GetPlayer(name);
            PlayerListEntry entry = this.playerListEntries.Find((a) =>
            {
                return a.Name == name;
            });
            this.playerListEntries.Remove(entry);

            this.SendRemovePlayerLists(entry);
        }

        public Player[] GetPlayers()
        {
            return this.networkManager?.players.Values.ToArray();
        }

        public Player GetPlayer(string name)
        {
            Player[] players = this.GetPlayers();
            for (int i = 0; i < players.Length; ++i)
            {
                if (players[i].Name == name)
                    return players[i];
            }

            return null;
        }
    }
}
