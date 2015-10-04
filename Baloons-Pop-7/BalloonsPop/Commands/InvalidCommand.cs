namespace Balloons.Commands
{
    using System;

    public class InvalidCommand : ICommand
    {
        public string Name
        {
            get { return "invalid"; }
        }

        public void Execute(CommandContext context)
        {
            Console.WriteLine("Invalid command entered");
        }
    }
}
