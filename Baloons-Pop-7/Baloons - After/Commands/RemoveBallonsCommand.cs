namespace Balloons.Commands
{
    using System.Collections.Generic;

    using Balloons.Common;

    public class RemoveBallonsCommand
    {
        internal static void RemovePoppedBaloons(string[,] gameField)
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

                row = 4;
                while (currentGameField.Count > 0)
                {
                    gameField[row, col] = currentGameField.Dequeue();
                    row--;
                }

                Helpers.Sound.PlayGameSound();

                currentGameField.Clear();
            }
        }
    }
}
