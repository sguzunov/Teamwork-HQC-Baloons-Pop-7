namespace Balloons.GameField
{
    using System;
    using System.Collections.Generic;

    using Balloons.Common;

    public static class Field
    {
        public static string[,] gameField = new string[GameConstants.WIDTH_OF_FIELD, GameConstants.HEIGHT_OF_FIELD];

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
    }
}
