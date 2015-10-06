namespace Balloons.Commands
{
    using Balloons.Cell;
    using Balloons.Common;
    using Balloons.FieldFactory;
    using Balloons.FieldFactory.Field;
    using Balloons.UI;
    using System;

    public class PopBalloonsCommand //: ICommand
    {
        private static int clearedCells = 0;
        public static int filledCells = GameConstants.FILLED_CELLS;


        // this method should be renamed to Pop???
        private void Pop(int row, int col, string activeCell, IGameField field)
        {
            bool validPop = IsPopValid(row, field.Rows) && IsPopValid(col, field.Columns);
            //string activeCell = field[row, col];
            if (validPop && (field[row, col].Symbol == activeCell))
            {
                field[row, col] = new BalloonPoped();
                clearedCells++;

                Pop(row - 1, col, activeCell, field); // Up
                Pop(row + 1, col, activeCell, field); // Down
                Pop(row, col + 1, activeCell, field); // Left
                Pop(row, col - 1, activeCell, field); // Right
            }
            else
            {
                filledCells -= clearedCells;
                clearedCells = 0;
                return;
            }
        }

        internal bool IsPopValid(int index, int boundValue)
        {
            if ((index >= 0) && (index < boundValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // this method should be removed from here
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

        public string Name
        {
            get { return "pop"; }
        }

        public void Execute(CommandContext context)
        {
            if (context.GameField == null)
            {
                throw new ArgumentNullException("board");
            }
            else
            {
                Pop(context.ActiveRow, context.ActiveCol, context.GameField[context.ActiveRow, context.ActiveCol].Symbol, context.GameField);
            }
        }
    }
}
