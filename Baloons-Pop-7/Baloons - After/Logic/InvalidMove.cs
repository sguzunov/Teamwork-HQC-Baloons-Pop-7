namespace Baloons.Logic
{
    using System;

    using Common;

    public class InvalidMove
    {
        internal static void DisplayMessage()
        {
            Console.WriteLine(GameMessages.INVALID_MOVE_MESSAGE);
        }
    }
}
