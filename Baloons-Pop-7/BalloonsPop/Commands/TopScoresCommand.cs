namespace Balloons.Commands
{
    using Balloons.Common;
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
            var topPlayers = ScoreBoard.Instance.GetSortedPlayers;

            if (topPlayers.Count > 0)
            {
                this.renderer.RenderGameMessage(GameMessages.TopScoresMessage);
                this.renderer.RenderGameTopPlayers(topPlayers);
            }
            else
            {
                this.renderer.RenderGameMessage(GameMessages.EmptyScoreBoardMessage);
            }
        }
    }
}
