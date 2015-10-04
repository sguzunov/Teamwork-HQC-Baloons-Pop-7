namespace Balloons.Commands
{
    using System.Collections.Generic;

    using Balloons.Common;
    using Balloons.GameRules;
    using Balloons.FieldFactory.Field;
    using Cell;

    public class ReorderBallonsStrategyDefault : ReorderBalloonsStrategy
    {
        public override void ReorderBalloons(IGameField gameField)
        {
            int row;
            int col;

            Queue<Balloon> currentGameField = new Queue<Balloon>();

            for (col = 0; col < gameField.Columns; col++)
            {
                for (row = 0; row < gameField.Rows; row++)
                {
                    if (!(gameField[row, col] is BalloonPoped))
                    {
                        currentGameField.Enqueue(gameField[row, col]);
                        gameField[row, col] = new BalloonPoped();
                    }
                }

                row = 0;
                while (currentGameField.Count > 0)
                {
                    gameField[row, col] = currentGameField.Dequeue();
                    row++;
                }

                currentGameField.Clear();
            }
        }
    }
}