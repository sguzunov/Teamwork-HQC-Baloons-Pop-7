namespace Balloons.Commands
{
    using System.Collections.Generic;

    using Balloons.Commands;

    public interface ICommandManager
    {
        ICommand GetCommand(IList<string> commandName);
    }
}
