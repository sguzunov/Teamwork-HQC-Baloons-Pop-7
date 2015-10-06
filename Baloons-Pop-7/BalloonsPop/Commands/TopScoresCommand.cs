namespace Balloons.Commands
{
    using System;

    using Balloons.GameScore;
    using Balloons.UI;

    public class TopScoresCommand : ICommand
    {
        private readonly IRenderer renderer;

        public TopScoresCommand(IRenderer renderer)
        {
            this.renderer = renderer;
            this.Name = "top";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            // TODO : Needs refactoring. The method is coupled to Scoreboard.
            Console.WriteLine("Tuk sym");
            this.renderer.RenderGameScoreBoard(ScoreBoard.Instance);
        }
    }
}
