namespace Balloons.Commands
{
    using System;

    using Balloons.Cell;
    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public class PopBalloonsCommand : ICommand
    {
        private readonly IGameField gameField;
        private readonly int activeRow;
        private readonly int activeCol;
        private IBalloonsFactory balloonsFactory;

        public PopBalloonsCommand(IBalloonsFactory balloonsFactory, IGameField gameField, int activeRow, int activeCol)
        {
            this.balloonsFactory = balloonsFactory;
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
                throw new ArgumentNullException("gameField");
            }

            var activeCellSymbol = this.gameField[this.activeRow, this.activeCol].Symbol;
            this.Pop(this.activeRow, this.activeCol, activeCellSymbol, this.gameField);
        }

        private void Pop(int activeRow, int activeCol, string activeCell, IGameField field)
        {
            bool isValidPop = this.IsPopValid(activeRow, field.Rows) && this.IsPopValid(activeCol, field.Columns);

            if (isValidPop && (field[activeRow, activeCol].Symbol == activeCell) && (field[activeRow, activeCol].Symbol != GameConstants.PopedBalloonSymbol))
            {
                field[activeRow, activeCol] = this.balloonsFactory.GetBalloon(GameConstants.PopedBalloonSymbol);

                // Up
                this.Pop(activeRow - 1, activeCol, activeCell, field);

                // Down
                this.Pop(activeRow + 1, activeCol, activeCell, field);

                // Left
                this.Pop(activeRow, activeCol + 1, activeCell, field);

                // Right
                this.Pop(activeRow, activeCol - 1, activeCell, field);
            }
        }

        private bool IsPopValid(int index, int boundValue)
        {
            if ((0 <= index) && (index < boundValue))
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
