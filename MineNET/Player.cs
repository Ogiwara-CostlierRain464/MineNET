using MineNET.Commands;
using MineNET.Entities;
using System;

namespace MineNET
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
    }
}
