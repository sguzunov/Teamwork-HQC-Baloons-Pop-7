namespace Balloons.ReorderStrategy
{
    using Balloons.Common;
    using Balloons.FieldFactory.Field;

    public class ReorderBallonsStrategyFly : ReorderBalloonsStrategy
    {
        public override void ReorderBalloons(IGameField gameField)
        {
            int rows = gameField.Rows;
            int columns = gameField.Columns;

            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (gameField[row, col].Symbol == GameConstants.PopedBalloonSymbol)
                    {
                        this.SwapWithNextUnPopedBalloon(gameField, row, col, rows);
                    }
                }
            }

            // int row;
            // int col;

            // Queue<Balloon> currentGameField = new Queue<Balloon>();

            // for (col = 0; col < gameField.Columns; col++)
            // {
            //     for (row = 0; row < gameField.Rows; row++)
            //     {
            //         if (!(gameField[row, col] is BalloonPoped))
            //         {
            //             currentGameField.Enqueue(gameField[row, col]);
            //             gameField[row, col] = new BalloonPoped();
            //         }
            //     }

            //     row = 0;
            //     while (currentGameField.Count > 0)
            //     {
            //         gameField[row, col] = currentGameField.Dequeue();
            //         row++;
            //     }

            //     currentGameField.Clear();
            // }
        }

        private void SwapWithNextUnPopedBalloon(IGameField gameField, int activeRow, int activeCol, int rows)
        {
            for (int row = activeRow + 1; row < rows; row++)
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