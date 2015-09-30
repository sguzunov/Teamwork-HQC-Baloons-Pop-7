namespace Balloons.Logic
{
    using System;

    using Balloons.Common;

    public class InvalidMove
    {
        internal static void DisplayMessage()
        {
            Console.WriteLine(GameMessages.INVALID_MOVE_MESSAGE);
        }
    }
}
