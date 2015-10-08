namespace Balloons.GameEngine
{
    using Balloons.FieldFactory.Field;

    public interface IBalloonsEngine
    {
        void InitializeGame();

        void StartGame();

        bool IsGameFinished(IGameField gameField);
    }
}
