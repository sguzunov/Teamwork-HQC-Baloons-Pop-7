﻿//namespace Balloons.Commands
//{
//    using System.Collections.Generic;

//    using Balloons.Common;
//    using Balloons.GameRules;
//    using Balloons.FieldFactory.Field;

//    public class ReorderBallonsStrategyFly : ReorderBalloonsStrategy
//    {
//        public override void ReorderBalloons(GameField gameField)
//        {
//            int row;
//            int col;

//            Queue<string> currentGameField = new Queue<string>();

//            for (col = gameField.Columns - 1; col >= 0; col--)
//            {
//                for (row = gameField.Rows - 1; row >= 0; row--)
//                {
//                    if (gameField[row, col] != ".")
//                    {
//                        currentGameField.Enqueue(gameField[row, col]);
//                        gameField[row, col] = ".";
//                    }
//                }

//                row = gameField.Rows - 1;
//                while (currentGameField.Count > 0)
//                {
//                    gameField[row, col] = currentGameField.Dequeue();
//                    row--;
//                }

//                currentGameField.Clear();
//            }
//        }
//    }
//}