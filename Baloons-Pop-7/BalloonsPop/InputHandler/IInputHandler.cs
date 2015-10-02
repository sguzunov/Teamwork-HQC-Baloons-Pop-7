namespace Balloons.InputHandler
{
    using System;

    public interface IInputHandler
    {
        string ReadInputCommand();

        string ReadGameMode();

        string ReadGameDifficulty();
    }
}
