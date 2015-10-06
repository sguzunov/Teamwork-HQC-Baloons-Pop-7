namespace Balloons.Commands
{
    using Balloons.Commands;

    public interface ICommandManager
    {
        ICommand GetCommand(string commandName);
    }
}
