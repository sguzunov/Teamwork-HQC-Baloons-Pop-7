namespace Baloons.Gamefield
{
    using System;

    using Common;
    using System.Collections.Generic;

    public static class GameField
    {
        public static string[,] gameField = new string[GameConstants.WIDTH, GameConstants.HEIGHT];

        public static string[,] InitialGameField(int width, int height)
        {
            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    gameField[row, col] = RandomGenerator.GetRandomInt();
                }
            }
            return gameField;
        }

        internal static void RemovePoppedBaloons()
        {
            int i;
            Queue<string> temp = new Queue<string>();
            for (int j = GameConstants.HEIGHT - 1; j >= 0; j--)
            {
                for (i = GameConstants.WIDTH - 1; i >= 0; i--)
                {
                    if (GameField.gameField[i, j] != ".")
                    {
                        temp.Enqueue(GameField.gameField[i, j]);
                        GameField.gameField[i, j] = ".";
                    }
                }
                i = 4;
                while (temp.Count > 0)
                {
                    GameField.gameField[i, j] = temp.Dequeue();
                    i--;
                }
                temp.Clear();
            }
        }


        // method Drow should be in a separate classe and maybe have an interface IDrowable??
        public static void Draw(string[,] gameField, int width, int height)
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < width; row++)
            {
                Console.Write(row + " | ");

                for (int col = 0; col < height; col++)
                {
                    Console.Write(gameField[row, col] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");
        }
    }
}
