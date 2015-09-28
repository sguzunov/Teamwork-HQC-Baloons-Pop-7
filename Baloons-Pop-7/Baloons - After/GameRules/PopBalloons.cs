namespace Balloons.GameRules
{
    using Balloons.Common;
    using Balloons.GameField;

    public class PopBaloons
    {
        private static int clearedCells = 0;
        private static int filledCells = GameConstants.FILLED_CELLS;

        internal static void Clear(int i, int j, string activeCell)
        {
            if ((i >= 0) && (i <= 4) && (j <= 9) && (j >= 0) && (Field.gameField[i, j] == activeCell))
            {
                Field.gameField[i, j] = ".";
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
            if (filledCells == 0)
            {
                filledCells = GameConstants.FILLED_CELLS;
                return true;                
            }
            else
            {
                return false;
            }
        }
    }
}
