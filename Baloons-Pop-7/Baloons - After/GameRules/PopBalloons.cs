namespace Balloons.GameRules
{
    using Balloons.Common;
    using Balloons.GameField;

    public class PopBalloons
    {
        private static int clearedCells = 0;
        private static int filledCells = GameConstants.FILLED_CELLS;

        // this method should be renamed to Pop???
        internal static void Clear(int row, int col, string activeCell)
        {
            bool validPop = IsPopValid(row, GameConstants.WIDTH_OF_FIELD) && IsPopValid(col, GameConstants.HEIGHT_OF_FIELD);

            if (validPop && (Field.gameField[row, col] == activeCell))
            {
                Field.gameField[row, col] = ".";
                clearedCells++;

                Clear(row - 1, col, activeCell); // Up
                Clear(row + 1, col, activeCell); // Down
                Clear(row, col + 1, activeCell); // Left
                Clear(row, col - 1, activeCell); // Right
            }
            else
            {
                filledCells -= clearedCells;
                clearedCells = 0;
                return;
            }
        }

        internal static bool IsPopValid(int index, int boundValue)
        {
            if ((index >= 0) && (index <= boundValue))
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        // this method should be remved from here
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
