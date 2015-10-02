namespace Balloons.InputHandler
{
    using Balloons.Common;

    public interface IInputHandler
    {
        string ReadInputCommand();

        GameMode GetGameMode();

        GameDifficulty GetGameDifficulty();
    }
}
