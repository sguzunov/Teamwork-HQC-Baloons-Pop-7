namespace Balloons.UI
{
    using Balloons.GameField;

    public interface IRenderer
    {
        void RenderGameField(IGameField field);

        void RenderMenu();

        void RenderCommands();

        void RenderGameScoreBoard();
    }
}
