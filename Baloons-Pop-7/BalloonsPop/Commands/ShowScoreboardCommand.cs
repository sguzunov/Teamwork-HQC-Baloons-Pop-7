namespace BalloonsPop.Commands
{
    using System;

    public class ShowScoreboardCommand :ICommand
    {
        public string Name
        {
            get { return "top"; }
        }

        public void Execute()
        {
            Console.WriteLine("The ShowScoreboard command should be implemented here");
        }
    }
}
