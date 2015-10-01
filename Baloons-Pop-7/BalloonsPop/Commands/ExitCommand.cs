namespace BalloonsPop.Commands
{
    using System;

    public class ExitCommand : ICommand
    {
        public void Execute()
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
