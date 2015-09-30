using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons.ConsoleUI
{
    public class ChangeBalloonColor
    {
        public static char DrawBalloonsInColor(string currentNumberToChange)
        {

            char symbol = '\u00A4';
            //// other chars
            //// smiling face = \u263b

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
                case ".":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    throw new InvalidOperationException("This symbol does not exists!");
            }

            return symbol;
        }
    }
}
