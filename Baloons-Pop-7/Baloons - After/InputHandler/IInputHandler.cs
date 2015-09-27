using System;

namespace Balloons.InputHandler
{
    public interface IInputHandler
    {
        string ReadInput();

        bool IsValidInput(string command);

        string ParseInput(string userInput);
    }
}
