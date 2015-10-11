namespace Balloons.GameEngine
{
    using Balloons.Common;

    public interface IBalloonsEngine
    {
        void InitializeGame(GameDifficulty gameDifficulty);

        void StartGame();
    }
}
