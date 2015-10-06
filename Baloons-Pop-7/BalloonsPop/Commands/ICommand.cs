namespace Balloons.Commands
{
    public interface ICommand
    {
        string Name { get; }

        void Execute();
    }
}