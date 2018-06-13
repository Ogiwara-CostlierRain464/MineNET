using MineNET.Commands;
using MineNET.Data;
using MineNET.Network;
using MineNET.Network.MinecraftPackets;
using MineNET.Network.RakNetPackets;
using MineNET.Values;
using MineNET.Worlds;
using System;
using System.Net;

namespace MineNET.Entities.Players
{
    public class Player : Entity, CommandSender
    {
        #region Property & Field
        public override bool IsPlayer
        {
            get
            {
                return true;
            }
        }

        public override string Name { get; protected set; }
        public string DisplayName { get; private set; }

        public IPEndPoint EndPoint { get; internal set; }

        public bool IsPreLogined { get; private set; }
        public bool IsLogined { get; private set; }
        public LoginData LoginData { get; private set; }
        public ClientData ClientData { get; private set; }
        public Skin Skin { get; private set; }
        public UUID Uuid { get; private set; }

        public GameMode GameMode { get; private set; }

        public bool PackSyncCompleted { get; private set; }
        public bool HaveAllPacks { get; private set; }
        #endregion

        #region Send Message Method
        public void SendMessage(TranslationMessage message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message, params object[] args)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Send Status Packet
        public void SendPlayStatus(int status, int flag = RakNetProtocol.FlagNormal)
        {
            PlayStatusPacket pk = new PlayStatusPacket();
            pk.Status = status;

            this.SendPacket(pk, flag: flag);
        }
        #endregion

        #region Send Packet Method
        public void SendPacket(MinecraftPacket packet, int reliability = RakNetPacketReliability.RELIABLE, int flag = RakNetProtocol.FlagNormal)
        {
            NetworkSession session = Server.Instance.Network.GetSession(this.EndPoint);
            if (session == null)
            {
                return;
            }

            session.AddPacketBatchQueue(packet, reliability, flag);
        }
        #endregion

        #region Packet Handle Method
        public void OnPacketHandle(MinecraftPacket packet)
        {
            if (packet is LoginPacket)
            {
                this.HandleLoginPacket((LoginPacket) packet);
            }
            else if (packet is ResourcePackClientResponsePacket)
            {
                this.HandleResourcePackClientResponsePacket((ResourcePackClientResponsePacket) packet);
            }
        }

        public void HandleLoginPacket(LoginPacket pk)
        {
            if (this.IsPreLogined)
            {
                return;
            }

            if (pk.Protocol < MinecraftProtocol.ClientProtocol)
            {
                this.SendPlayStatus(PlayStatusPacket.LOGIN_FAILED_CLIENT, RakNetProtocol.FlagImmediate);
                this.Close("disconnectionScreen.outdatedClient");
                return;
            }
            else if (pk.Protocol > MinecraftProtocol.ClientProtocol)
            {
                this.SendPlayStatus(PlayStatusPacket.LOGIN_FAILED_SERVER, RakNetProtocol.FlagImmediate);
                this.Close("disconnectionScreen.outdatedServer");
                return;
            }

            Player[] players = Server.Instance.GetPlayers();
            for (int i = 0; i < players.Length; ++i)
            {
                if (players[i].GetHashCode() != this.GetHashCode())
                {
                    if (players[i].Name == this.Name)
                    {
                        this.Close("disconnectionScreen.loggedinOtherLocation");
                        return;
                    }
                }
            }

            //TODO: Auth MS Server

            this.LoginData = pk.LoginData;
            this.Name = pk.LoginData.DisplayName;
            this.DisplayName = this.Name;
            this.Uuid = this.LoginData.ClientUUID;

            this.ClientData = pk.ClientData;
            this.Skin = this.ClientData.Skin;

            //TODO: Event

            this.IsPreLogined = true;

            this.SendPlayStatus(PlayStatusPacket.LOGIN_SUCCESS);

            ResourcePacksInfoPacket info = new ResourcePacksInfoPacket();
            this.SendPacket(info);
        }

        public void HandleResourcePackClientResponsePacket(ResourcePackClientResponsePacket pk)
        {
            if (this.PackSyncCompleted)
            {
                return;
            }

            if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_REFUSED)
            {
                this.Close("disconnectionScreen.resourcePack");
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_SEND_PACKS)
            {
                //TODO: ResourcePackDataInfoPacket
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_HAVE_ALL_PACKS)
            {
                ResourcePackStackPacket resourcePackStackPacket = new ResourcePackStackPacket();
                this.SendPacket(resourcePackStackPacket);

                this.HaveAllPacks = true;
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_COMPLETED && this.HaveAllPacks)
            {
                if (this.IsLogined)
                {
                    return;
                }

                //TODO: Event

                this.IsLogined = true;

                //TODO: Load NBT

                StartGamePacket startGamePacket = new StartGamePacket();
                startGamePacket.EntityUniqueId = this.EntityID;
                startGamePacket.EntityRuntimeId = this.EntityID;
                startGamePacket.PlayerGamemode = this.GameMode;
                startGamePacket.PlayerPosition = new Vector3(this.X, this.Y, this.Z);
                startGamePacket.Direction = new Vector2(this.Yaw, this.Pitch);
                /*.WorldGamemode = this.World.DefaultGameMode.GameModeToInt();
                startGamePacket.Difficulty = this.World.Difficulty;
                startGamePacket.SpawnX = this.World.SpawnPoint.FloorX;
                startGamePacket.SpawnY = this.World.SpawnPoint.FloorY;
                startGamePacket.SpawnZ = this.World.SpawnPoint.FloorZ;*/
                startGamePacket.WorldName = "Test";//this.World.Name;
                this.SendPacket(startGamePacket);

                this.SendPlayStatus(PlayStatusPacket.PLAYER_SPAWN);
            }
        }
        #endregion

        #region Close Player Method
        public void Close(string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                DisconnectPacket pk = new DisconnectPacket();
                pk.Message = reason;

                this.SendPacket(pk, flag: RakNetProtocol.FlagImmediate);
            }

            Server.Instance.Network.GetSession(this.EndPoint)?.Disconnect(reason);
        }
        #endregion
    }
}
