namespace BalloonsPop.Commands
{
    public interface ICommand
    {
        string Name { get; }

        void Execute();
    } 
}