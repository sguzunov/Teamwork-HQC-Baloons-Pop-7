namespace Balloons.Commands
{
    using System.Collections.Generic;

    using Balloons.Common;
    using Balloons.GameRules;

    public class ReorderBallonsStrategyFly : ReorderBalloonsStrategy
    {
        public override void ReorderBalloons(string[,] gameField)
        {
            int row;
            int col;

            Queue<string> currentGameField = new Queue<string>();

            for (col = GameConstants.HEIGHT_OF_FIELD - 1; col >= 0; col--)
            {
                for (row = GameConstants.WIDTH_OF_FIELD - 1; row >= 0; row--)
                {
                    if (gameField[row, col] != ".")
                    {
                        currentGameField.Enqueue(gameField[row, col]);
                        gameField[row, col] = ".";
                    }
                }

                row = GameConstants.WIDTH_OF_FIELD - 1;
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