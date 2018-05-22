using MineNET.Events.PlayerEvents;
using MineNET.Events.ServerEvents;
using System;

namespace MineNET.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private CommandManager Manager { get; }

        public event EventHandler<ServerCommandEventArgs> ServerCommand;
        public void OnServerCommand(object sender, ServerCommandEventArgs e)
        {
            this.ServerCommand?.Invoke(sender, e);
        }
        public event EventHandler<PlayerCommandEventArgs> PlayerCommand;
        public void OnPlayerCommand(object sender, PlayerCommandEventArgs e)
        {
            this.PlayerCommand?.Invoke(sender, e);
        }
        public CommandHandler(CommandManager manager)
        {
            this.Manager = manager;
        }

        public void OnCommandExecute(CommandData data)
        {
            if (data.Sender.IsPlayer)
            {
                PlayerCommandEventArgs ev = new PlayerCommandEventArgs((Player) data.Sender, data.Text);
                this.OnPlayerCommand(this, ev);
                if (ev.IsCancel)
                {
                    return;
                }

                data.Text = ev.Command;
            }
            else
            {
                ServerCommandEventArgs ev = new ServerCommandEventArgs(Server.Instance, data.Text);
                this.OnServerCommand(this, ev);
                if (ev.IsCancel)
                {
                    return;
                }

                data.Text = ev.Command;
            }
            data.SplitText();

            Command command = this.Manager.GetCommand(data.Command);
            if (command != null)
            {
                command.OnExecute(data.Sender, data.Args);
            }
            else
            {
                //data.Sender.SendMessage(new TranslationMessage(ColorText.RED, "commands.generic.unknown", data.Command));
            }
        }
    }
}
