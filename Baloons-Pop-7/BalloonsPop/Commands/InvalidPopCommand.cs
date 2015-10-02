namespace Balloons.Commands
{
    using System;

    public class InvalidPopCommand : ICommand
    {
        public string Name
        {
            get { return "invalid pop"; }
        }

        public void Execute()
        {
            Console.WriteLine("Invalid pop!");
        }
    }
}
