namespace Balloons.Commands
{
    using System;

    public class PopBalloonsCommand :ICommand
    {
        public string Name
        {
            get { return "pop"; }
        }

        public void Execute(CommandContext context)
        {
            Console.WriteLine(); ;
        }
    }
}
