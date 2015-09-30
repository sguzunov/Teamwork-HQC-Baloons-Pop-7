namespace Balloons.Logic
{
    using System;

    using Balloons.Common;

    public class InvalidCommand
    {
        internal static void DisplayMessage()
        {
            Console.WriteLine(GameMessages.INVALID_COMMAND_MESSAGE);
        }
    }
}
