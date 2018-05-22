using MineNET.Commands.Defaults;
using System;
using System.Collections.Generic;

namespace MineNET.Commands
{
    public class CommandManager : IDisposable
    {
        #region Property & Field
        public ICommandHandler CommandHandler { get; set; }
        public Dictionary<string, Command> CommandList { get; private set; } = new Dictionary<string, Command>();
        public Dictionary<string, Command> CommandAliases { get; private set; } = new Dictionary<string, Command>();
        #endregion

        #region Ctor
        public CommandManager()
        {
            this.CommandHandler = new CommandHandler(this);
            this.RegisterDefaultCommands();
        }
        #endregion

        #region Get Command Method
        public Command GetCommand(string cmd)
        {
            if (this.CommandList.ContainsKey(cmd))
            {
                return this.CommandList[cmd];
            }
            if (this.CommandAliases.ContainsKey(cmd))
            {
                return this.CommandAliases[cmd];
            }
            return null;
        }

        public bool TryGetCommand(string cmd, out Command command)
        {
            command = this.GetCommand(cmd);
            if (command != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Register / UnRegister Command Method
        public bool RegisterCommand(Command cmd)
        {
            bool result = false;
            if (!this.CommandList.ContainsKey(cmd.Name))
            {
                this.CommandList.Add(cmd.Name, cmd);
                result = true;
            }

            if (cmd.Aliases != null)
            {
                for (int i = 0; i < cmd.Aliases.Length; ++i)
                {
                    if (!this.CommandAliases.ContainsKey(cmd.Aliases[i]))
                    {
                        this.CommandAliases.Add(cmd.Aliases[i], cmd);
                    }
                }
                result = true;
            }

            return result;
        }

        public bool UnRegisterCommand(string cmdName)
        {
            if (this.CommandList.ContainsKey(cmdName))
            {
                this.CommandList.Remove(cmdName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UnRegisterCommand(Command cmd)
        {
            bool result = this.UnRegisterCommand(cmd.Name);

            if (cmd.Aliases != null)
            {
                for (int i = 0; i < cmd.Aliases.Length; ++i)
                {
                    if (!this.CommandAliases.ContainsKey(cmd.Aliases[i]))
                    {
                        this.CommandAliases.Remove(cmd.Aliases[i]);
                    }
                }
                result = true;
            }

            return result;
        }
        #endregion

        #region Default Command Register Method
        private void RegisterDefaultCommands()
        {
            this.RegisterCommand(new StopCommand());
        }
        #endregion

        #region Dispose Method
        public void Dispose()
        {
            this.CommandList.Clear();
            this.CommandAliases = null;
        }
        #endregion
    }
}
