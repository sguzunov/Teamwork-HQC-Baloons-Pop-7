namespace Balloons.Helpers
{
    using System;

    public class ConsoleHelper
    {
        public static void CentraliseCursor(int textLength)
        {
            int leftPosition = (Console.WindowWidth / 2) - (textLength / 2);
            int topPosition = Console.CursorTop;
            Console.SetCursorPosition(leftPosition, topPosition);
        }
    }
}
