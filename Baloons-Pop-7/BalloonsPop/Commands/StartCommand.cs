namespace Balloons.Commands
{
    using System;

    public class StartCommand : ICommand
    {
        public string Name
        {
            get { return "start"; }
        }

        public void Execute()
        {
            Console.WriteLine("From here we should start the game");
        }
    }
}
