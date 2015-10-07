namespace Balloons.GameEngine
{
    public interface IBalloonsEngine
    {
        void InitializeGame();

        void StartGame();

        bool IsGameFinished();
    }
}
