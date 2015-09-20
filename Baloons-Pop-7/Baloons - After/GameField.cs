namespace Baloons
{
    using System;

    using Common;

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
