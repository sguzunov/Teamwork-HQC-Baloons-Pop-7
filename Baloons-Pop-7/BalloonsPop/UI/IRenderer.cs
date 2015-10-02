namespace Balloons.UI
{
    using Balloons.FieldFactory.Field;
    using Balloons.GameScore;

    public interface IRenderer
    {
        void RenderGameField(IGameField field);

        void RenderMenu();

        void RenderCommands();

        void RenderGameScoreBoard(ScoreBoard scoreboard);
    }
}
