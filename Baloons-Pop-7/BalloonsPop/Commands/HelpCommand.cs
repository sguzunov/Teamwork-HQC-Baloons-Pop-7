namespace Balloons.Commands
{
    using System;

    public class HelpCommand : ICommand
    {
        public string Name
        {
            get { return "help"; }
        }

        public void Execute()
        {
            Console.WriteLine("Implement the help command: some message");
        }
    }
}
