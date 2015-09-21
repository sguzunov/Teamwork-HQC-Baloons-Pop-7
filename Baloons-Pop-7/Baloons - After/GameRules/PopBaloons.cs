using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baloons.GameRules
{
    using Common;

    public class PopBaloons
    {
        private static int clearedCells = 0;
        private static int filledCells = GameConstants.WIDTH* GameConstants.HEIGHT;

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
