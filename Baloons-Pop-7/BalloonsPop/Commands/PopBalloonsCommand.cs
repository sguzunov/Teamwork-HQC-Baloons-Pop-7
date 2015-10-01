namespace BalloonsPop.Commands
{
    using System;

    public class PopBalloonsCommand :ICommand
    {
        public string Name
        {
            get { return "pop"; }
        }

        public void Execute()
        {
            Console.WriteLine(); ;
        }
    }
}
