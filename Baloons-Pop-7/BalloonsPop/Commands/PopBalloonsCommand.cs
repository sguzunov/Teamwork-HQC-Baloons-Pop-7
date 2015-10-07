namespace Balloons.Commands
{
    using System;

    using Balloons.Cell;
    using Balloons.Common;
    using Balloons.FieldFactory.Field;
    using Balloons.UI;

    public class PopBalloonsCommand : ICommand
    {
        private readonly IRenderer renderer;
        private readonly IGameField gameField;
        private readonly int activeRow;
        private readonly int activeCol;


        public PopBalloonsCommand(IRenderer renderer, IGameField gameField, int activeRow, int activeCol)
        {
            this.renderer = renderer;
            this.gameField = gameField;
            this.activeRow = activeRow;
            this.activeCol = activeCol;
            this.Name = "pop";
        }

        public string Name { get; private set; }

        public void Execute()
        {
            if (this.gameField == null)
            {
                throw new ArgumentNullException("gamefield");
            }
            else
            {
                Pop(this.activeRow, this.activeCol, this.gameField[this.activeRow, this.activeCol].Symbol, this.gameField);
            }
        }

        private void Pop(int row, int col, string activeCell, IGameField field)
        {
            bool validPop = IsPopValid(row, field.Rows) && IsPopValid(col, field.Columns);

            if (validPop && (field[row, col].Symbol == activeCell) && (field[row, col].Symbol != "."))
            {
                field[row, col] = new BalloonPoped();

                Pop(row - 1, col, activeCell, field); // Up
                Pop(row + 1, col, activeCell, field); // Down
                Pop(row, col + 1, activeCell, field); // Left
                Pop(row, col - 1, activeCell, field); // Right
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
    }
}
