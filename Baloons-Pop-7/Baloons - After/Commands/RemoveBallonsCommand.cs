namespace Balloons.Commands
{
    using Balloons.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveBallonsCommand
    {
        internal static void RemovePoppedBaloons(string[,] gameField)
        {
            int i;
            Queue<string> temp = new Queue<string>();
            for (int j = GameConstants.HEIGHT_OF_FIELD - 1; j >= 0; j--)
            {
                for (i = GameConstants.WIDTH_OF_FIELD - 1; i >= 0; i--)
                {
                    if (gameField[i, j] != ".")
                    {
                        temp.Enqueue(gameField[i, j]);
                        gameField[i, j] = ".";
                    }
                }
                i = 4;
                while (temp.Count > 0)
                {
                    gameField[i, j] = temp.Dequeue();
                    i--;
                }
                temp.Clear();
            }
        }
    }
}
