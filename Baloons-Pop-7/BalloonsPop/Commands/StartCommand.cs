namespace Balloons.Commands
{
    using System;

    public class StartCommand// : ICommand
    {
        public string Name
        {
            get { return "start"; }
        }

        public void Execute(CommandContext context)
        {
            Console.WriteLine("From here we should start the game");
        }
    }
}
