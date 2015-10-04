namespace Balloons.Commands
{
    using System.Collections.Generic;

    using Balloons.Common;
    using Balloons.GameRules;
    using Balloons.FieldFactory.Field;
    using Cell;

    public class ReorderBallonsStrategyFly : ReorderBalloonsStrategy
    {
        public override void ReorderBalloons(IGameField gameField)
        {
            int row;
            int col;

            Queue<Balloon> currentGameField = new Queue<Balloon>();

            for (col = gameField.Columns - 1; col >= 0; col--)
            {
                for (row = gameField.Rows - 1; row >= 0; row--)
                {
                    if (!(gameField[row, col] is BalloonPoped))
                    {
                        currentGameField.Enqueue(gameField[row, col]);
                        gameField[row, col] = new BalloonPoped();
                    }
                }

                row = gameField.Rows - 1;
                while (currentGameField.Count > 0)
                {
                    gameField[row, col] = currentGameField.Dequeue();
                    row--;
                }

                currentGameField.Clear();
            }
        }
    }
}