﻿namespace Balloons.GameRules
{
    using Balloons.Common;
    using Balloons.GameField;

    public class PopBaloons
    {
        private static int clearedCells = 0;
        private static int filledCells = GameConstants.WIDTH_OF_FIELD * GameConstants.HEIGHT_OF_FIELD;

        internal static void Clear(int i, int j, string activeCell)
        {
            if ((i >= 0) && (i <= 4) && (j <= 9) && (j >= 0) && (GameField.gameField[i, j] == activeCell))
            {
                GameField.gameField[i, j] = ".";
                clearedCells++;
                //Up
                Clear(i - 1, j, activeCell);
                //Down
                Clear(i + 1, j, activeCell);
                //Left
                Clear(i, j + 1, activeCell);
                //Right
                Clear(i, j - 1, activeCell);
            }
            else
            {
                filledCells -= clearedCells;
                clearedCells = 0;
                return;
            }
        }

        internal static bool IsFinished()
        {
            return (filledCells == 0);
        }
    }
}
