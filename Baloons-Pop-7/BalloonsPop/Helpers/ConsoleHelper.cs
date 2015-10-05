using Balloons.Common;

namespace Balloons.Helpers
{
    using System;
    using System.Threading;

    public class ConsoleHelper
    {
        private const string ColorErrorMessage = "This balloon color does not exists ";

        public static void CentraliseCursor(int textLength)
        {
            int leftPosition = (Console.WindowWidth / 2) - (textLength / 2);
            int topPosition = Console.CursorTop;
            Console.SetCursorPosition(leftPosition, topPosition);
        }

        public static void ChangeForegroundColorDependingOnSymbol(BalloonsColors color)
        {
            switch (color)
            {
                case BalloonsColors.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case BalloonsColors.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case BalloonsColors.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case BalloonsColors.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case BalloonsColors.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    throw new InvalidOperationException(ColorErrorMessage);
            }
        }

        public static void DisplayInputErrorMessage(string message)
        {
            ClearConsoleLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(500);
            ClearConsoleLine();
        }

        private static void ClearConsoleLine()
        {
            var currentLine = Console.CursorTop - 1;

            Console.SetCursorPosition(0, currentLine);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}
