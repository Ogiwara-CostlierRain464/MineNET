namespace MineNET.Commands
{
    public interface ICommandHandler
    {
        void OnCommandExecute(CommandData data);
        void OnPlayerCommandExecute(CommandData data);
    }
}
