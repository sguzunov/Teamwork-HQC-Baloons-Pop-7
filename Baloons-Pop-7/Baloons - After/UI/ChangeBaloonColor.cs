
namespace Balloons.ConsoleUI
{
    using System;

    class PrintMenu
    {
        public static char DrawBaloonsInColor(string currentNumberToChange)
        {
            char symbol = '\u00A4';
            switch (currentNumberToChange)
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
                default:
                    break;
            }
            return symbol;
        }
    }
}
