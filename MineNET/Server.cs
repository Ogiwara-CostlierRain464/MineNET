﻿using System;
using System.Net;
using MineNET.Events.ServerEvents;
using MineNET.IO;
using MineNET.Manager;
using MineNET.Network;

namespace MineNET
{
    public sealed class Server : IDisposable
    {
        #region Singleton Instance
        public static Server Instance { get; private set; }

        public static string ExecutePath { get; } = Environment.CurrentDirectory;
        #endregion

        #region Property & Field
        public ServerStatus Status { get; private set; } = ServerStatus.Stop;

        public ConstantClockManager Clock { get; private set; }

        public MineNETConfig Config { get; private set; }
        public ServerConfig ServerProperty { get; private set; }

        public ILogger Logger { get; private set; }

        public INetworkSocket NetworkSocket { get; private set; }
        public NetworkManager Network { get; private set; }
        #endregion

        #region Event
        public event EventHandler<ServerStartEventArgs> ServerStart;
        private void OnServerStart(object sender, ServerStartEventArgs e)
        {
            this.ServerStart?.Invoke(sender, e);
        }

        public event EventHandler<ServerStopEventArgs> ServerStop;
        private void OnServerStop(object sender, ServerStopEventArgs e)
        {
            this.ServerStop?.Invoke(sender, e);
        }
        #endregion

        #region Ctor
        public Server()
        {
            Server.Instance = this;
        }
        #endregion

        #region Start & Stop Method
        public bool Start()
        {
            if (this.Status == ServerStatus.Stop)
            {
                try
                {
                    this.Clock = new ConstantClockManager();

                    //InitConfig
                    this.Config = MineNETConfig.Load<MineNETConfig>($"{ExecutePath}\\MineNET.yml");
                    this.ServerProperty = ServerConfig.Load<ServerConfig>($"{ExecutePath}\\ServerProperties.yml");

                    if (this.Logger == null)
                    {
                        this.Logger = new Logger();
                    }

                    OutLog.Info("%server.start");

                    if (this.NetworkSocket == null)
                    {
                        IPEndPoint point = new IPEndPoint(IPAddress.Any, this.ServerProperty.ServerPort);
                        this.SetNetworkSocket(new UDPSocket(point));
                    }
                    this.Network = new NetworkManager();

                    this.Status = ServerStatus.Running;
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this.Status = ServerStatus.Error;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Restart()
        {

        }

        public bool Stop()
        {
            if (this.Status == ServerStatus.Running)
            {
                try
                {
                    this.Status = ServerStatus.Stop;
                    return true;
                }
                catch
                {
                    this.Status = ServerStatus.Error;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ForceStop()
        {
            if (this.Status == ServerStatus.Running)
            {
                bool result = true;
                try
                {

                }
                catch
                {
                    result = false;
                }
                finally
                {
                    this.Status = ServerStatus.Stop;
                }

                return result;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Interface Set Method
        public bool SetNetworkSocket(INetworkSocket socket)
        {
            if (this.Status == ServerStatus.Stop)
            {
                this.NetworkSocket = socket;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetLoggger(ILogger logger)
        {
            if (this.Status == ServerStatus.Stop)
            {
                this.Logger = logger;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        public void Dispose()
        {

        }
    }
}
