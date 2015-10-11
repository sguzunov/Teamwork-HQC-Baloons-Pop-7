namespace Balloons.ReorderStrategy
{
    using System;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    /// <summary>
    /// This class gives strategy for ordering matrix in a way to move the field cells with numbers at a bigger row.
    /// </summary>
    public class ReorderBalloonsStrategyDefault : ReorderBalloonsStrategy
    {
        private const string FieldNullErrorMessage = "Null field cannot be reorderd";

        /// <summary>
        /// Orders matrix cells that have numbers in them in a bigger row number and those with "." at a lower row.
        /// </summary>
        /// <param name="gameField">Field to reorder.</param>
        public override void ReorderBalloons(IGameField gameField)
        {
            if (ObjectValidator.IsGameObjectNull(gameField))
            {
                throw new ArgumentNullException(FieldNullErrorMessage);
            }

            int rows = gameField.Rows;
            int columns = gameField.Columns;

            for (int col = 0; col < columns; col++)
            {
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (gameField[row, col].Symbol == GameConstants.PopedBalloonSymbol)
                    {
                        this.SwapWithNextUnpopedBalloon(gameField, row, col);
                    }
                }
            }
        }

        private void SwapWithNextUnpopedBalloon(IGameField gameField, int activeRow, int activeCol)
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