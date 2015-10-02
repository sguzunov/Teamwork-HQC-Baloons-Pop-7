namespace Balloons.Helpers
{
    using System;
    using System.Threading;

    public class ConsoleHelper
    {
        public static void CentraliseCursor(int textLength)
        {
            int leftPosition = (Console.WindowWidth / 2) - (textLength / 2);
            int topPosition = Console.CursorTop;
            Console.SetCursorPosition(leftPosition, topPosition);
        }

        public static void ChangeForegroundColorDependingOnSymbol(string symbol)
        {
            switch (symbol)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case ".":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    throw new InvalidOperationException("This symbol does not exists!");
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
    }
}
