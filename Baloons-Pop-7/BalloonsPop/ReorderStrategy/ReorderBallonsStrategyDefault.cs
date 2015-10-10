namespace Balloons.ReorderStrategy
{
    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public class ReorderBallonsStrategyDefault : ReorderBalloonsStrategy
    {
        public override void ReorderBalloons(IGameField gameField)
        {
            int rows = gameField.Rows;
            int columns = gameField.Columns;

            for (int col = 0; col < columns; col++)
            {
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (gameField[row, col].Symbol == GameConstants.PopedBalloonSymbol)
                    {
                        this.SwapWithNextUnPopedBalloon(gameField, row, col, rows);
                    }
                }
            }
        }

        private void SwapWithNextUnPopedBalloon(IGameField gameField, int activeRow, int activeCol, int rows)
        {
            for (int row = activeRow - 1; row >= 0; row--)
            {
                if (gameField[row, activeCol].Symbol != GameConstants.PopedBalloonSymbol)
                {
                    var oldValue = gameField[activeRow, activeCol];
                    gameField[activeRow, activeCol] = gameField[row, activeCol];
                    gameField[row, activeCol] = oldValue;
                    return;
                }
            }
        }
    }
}