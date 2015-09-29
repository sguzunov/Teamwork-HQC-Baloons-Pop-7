namespace Balloons.UI
{
    using Balloons.GameField;
    using Balloons.GameScore;

    public interface IRenderer
    {
        void RenderGameField(IGameField field);

        void RenderMenu();

        void RenderCommands();

        void RenderGameScoreBoard(ScoreBoard scoreboard);
    }
}
