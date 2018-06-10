using MineNET.Commands;
using MineNET.Network.MinecraftPackets;
using System;

namespace MineNET.Entities.Players
{
    public class Player : Entity, CommandSender
    {
        public bool IsPlayer
        {
            get
            {
                return true;
            }
        }

        public string Name { get; set; }

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

        #region Packet Handle Method
        public void OnPacketHandle(MinecraftPacket packet)
        {
            if (packet is LoginPacket)
            {
                this.HandleLoginPacket((LoginPacket) packet);
            }
        }

        public void HandleLoginPacket(LoginPacket packet)
        {
            OutLog.Info(packet.Protocol);
        }
        #endregion
    }
}
