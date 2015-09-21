namespace Baloons.Commands
{
    using Commands;

    internal class RestartCommand
    {
        internal static void Restart()
        {
            StartCommand.Start();
        }
    }
}
