namespace Balloons.InputHandler
{
    using System;

    public interface IInputHandler
    {
        string ReadInput();

        bool IsValidInput(string command);

        string ParseInput(string userInput);
    }
}
