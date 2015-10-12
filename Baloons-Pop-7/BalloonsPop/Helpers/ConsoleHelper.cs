namespace Balloons.Helpers
{
    using System;
    using System.Threading;

    using Balloons.Common;
    using Balloons.Common.ConsoleContext;

    /// <summary>
    /// Helper class provides methods for easy working with console.
    /// </summary>
    public static class ConsoleHelper
    {
        private const string ColorErrorMessage = "This balloon color does not exists!";
        private const string TextLenghtErrorMessage = "Text length must be bigger than 0 and less than console width!";

        /// <summary>
        /// Depending on text width and console window width centralize cursor.
        /// </summary>
        /// <param name="textLength">Length of the text for printing.</param>
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

        /// <summary>
        /// Sets the foreground color depending the needed one.
        /// </summary>
        /// <param name="color">The color the needs to be set.</param>
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

        /// <summary>
        /// A method which knows how exactly to render error messages.
        /// </summary>
        /// <param name="message">Message that needs to be printed.</param>
        /// <param name="consoleWriter">Console context for rendering the message.</param>
        public static void DisplayInputErrorMessage(string message, IConsoleWriter consoleWriter)
        {
            ClearConsoleLine(consoleWriter);
            Console.ForegroundColor = ConsoleColor.Red;
            consoleWriter.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(500);
            ClearConsoleLine(consoleWriter);
        }

        /// <summary>
        /// Clears whole console window.
        /// </summary>
        public static void ClearConsole()
        {
            Console.Clear();
        }

        /// <summary>
        /// Clears the exact line the cursor is.
        /// </summary>
        /// <param name="consoleWriter">Console context.</param>
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
