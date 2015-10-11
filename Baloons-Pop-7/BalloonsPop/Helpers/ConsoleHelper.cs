namespace Balloons.Helpers
{
    using System;
    using System.Threading;

    using Balloons.Common;
    using Balloons.UI;

    public static class ConsoleHelper
    {
        private const string ColorErrorMessage = "This balloon color does not exists!";
        private const string TextLenghtErrorMessage = "Text length must be bigger than 0 and less than console width!";

        public static void CentraliseCursor(int textLength)
        {
            if (textLength <= 0 || Console.WindowWidth <= textLength)
            {
                throw new IndexOutOfRangeException(TextLenghtErrorMessage);
            }

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

        public static void DisplayInputErrorMessage(string message, IConsoleWriter consoleWriter)
        {
            ClearConsoleLine(consoleWriter);
            Console.ForegroundColor = ConsoleColor.Red;
            consoleWriter.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(500);
            ClearConsoleLine(consoleWriter);
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        private static void ClearConsoleLine(IConsoleWriter consoleWriter)
        {
            var currentLine = 1;
            if (Console.CursorTop < 2)
            {
                currentLine = Console.CursorTop;
            }
            else
            {
                currentLine = Console.CursorTop - 1;
            }

            Console.SetCursorPosition(0, currentLine);
            consoleWriter.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }
    }
}
