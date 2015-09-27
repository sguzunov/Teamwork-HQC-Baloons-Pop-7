namespace Balloons.ConsoleUI
{
    using System;

    public class FieldDrawer
    {

        public static void Draw(string[,] gameField, int width, int height)
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < width; row++)
            {
                Console.Write(row + " | ");

                for (int col = 0; col < height; col++)
                {
                    if (gameField[row, col] == ".")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(gameField[row, col] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(gameField[row, col] + " ");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");
        }
    }
}

