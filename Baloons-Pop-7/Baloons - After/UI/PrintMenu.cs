
namespace Balloons.ConsoleUI
{
    using System;

    class PrintMenu
    {
        public static void DrawBaloonsInColor(string currentNumberToChange)
        {
            char symbol = '\u00A4';
            switch (currentNumberToChange)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(currentNumberToChange = symbol + " ");
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(currentNumberToChange = symbol + " ");
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(currentNumberToChange = symbol + " ");
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(currentNumberToChange = symbol + " ");
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(currentNumberToChange = symbol + " ");
                    break;
                default:
                    break;

            }
        }
    }
}
