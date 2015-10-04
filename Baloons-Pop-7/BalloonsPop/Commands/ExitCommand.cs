namespace Balloons.Commands
{
    using System;

    public class ExitCommand : ICommand
    {
        public void Execute(CommandContext context)
        {
            Console.WriteLine("Exit command");
            Environment.Exit(15);
        }

        public string Name
        {
            get { return "exit"; }
        }
    }
}
