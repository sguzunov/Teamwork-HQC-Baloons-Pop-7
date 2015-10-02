namespace Balloons.Commands
{
    using System;

    public class InvalidCommand : ICommand
    {
        public string Name
        {
            get { return "invalid"; }
        }

        public void Execute()
        {
            Console.WriteLine("Invalid command entered");
        }
    }
}
