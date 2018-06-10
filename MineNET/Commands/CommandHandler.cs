using MineNET.Entities.Players;
using MineNET.Events.PlayerEvents;
using MineNET.Events.ServerEvents;

namespace MineNET.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private CommandManager Manager { get; }

        public CommandHandler(CommandManager manager)
        {
            this.Manager = manager;
        }

        public void OnCommandExecute(CommandData data)
        {
            if (data.Sender.IsPlayer)
            {
                PlayerCommandEventArgs ev = new PlayerCommandEventArgs((Player) data.Sender, data.Text);
                Server.Instance.Event.Player.OnPlayerCommand(this, ev);
                if (ev.IsCancel)
                {
                    return;
                }

                data.Text = ev.Command;
            }
            else
            {
                ServerCommandEventArgs ev = new ServerCommandEventArgs(data.Text);
                Server.Instance.Event.Server.OnServerCommand(this, ev);
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
