namespace Balloons.Commands
{
    using Balloons.Cell;
    using Balloons.FieldFactory.Field;
    using Balloons.Memory;
    using Balloons.UI;

    public interface ICommandManager
    {
        ICommand ProcessCommand(string commandString, IRenderer renderer, IGameField field,
            IFieldMemoryManager fieldMemoryManager, IBalloonsFactory balloonsFactory);
    }
}
