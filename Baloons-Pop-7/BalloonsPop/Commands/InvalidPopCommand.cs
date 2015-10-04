namespace Balloons.Commands
{
    using System;

    public class InvalidPopCommand : ICommand
    {
        public string Name
        {
            get { return "invalid pop"; }
        }

        public void Execute(CommandContext context)
        {
            Console.WriteLine("Invalid pop!");
        }
    }
}
