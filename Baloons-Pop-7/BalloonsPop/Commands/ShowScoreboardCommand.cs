namespace Balloons.Commands
{
    using System;

    public class ShowScoreboardCommand :ICommand
    {
        public string Name
        {
            get { return "top"; }
        }

        public void Execute(CommandContext context)
        {
            Console.WriteLine("The ShowScoreboard command should be implemented here");
        }
    }
}
