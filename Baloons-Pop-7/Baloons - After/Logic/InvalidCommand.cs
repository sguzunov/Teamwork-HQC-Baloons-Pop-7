namespace Baloons.Logic
{
    using System;

    using Common;

    public class InvalidCommand
    {
        internal static void DisplayMessage()
        {
            Console.WriteLine(GameMessages.INVALID_COMMAND_MESSAGE);
        }
    }
}
