namespace Balloons.ConsoleUI
{
    using Balloons.GameField;

    public interface IRenderer
    {
        void RenderGameField(IGameField field);
    }
}
