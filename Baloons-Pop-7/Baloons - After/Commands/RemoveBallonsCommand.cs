﻿namespace Balloons.Commands
{
    using Balloons.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveBallonsCommand
    {
        internal static void RemovePoppedBaloons(string[,] gameField)
        {
            int row;
            int col;

            Queue<string> currentGameField = new Queue<string>();

            for (col = 0; col < GameConstants.HEIGHT_OF_FIELD; col++)
            {
                for (row = 0; row < GameConstants.WIDTH_OF_FIELD; row++)
                {
                    if (gameField[row, col] != ".")
                    {
                        currentGameField.Enqueue(gameField[row, col]);
                        gameField[row, col] = ".";
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
