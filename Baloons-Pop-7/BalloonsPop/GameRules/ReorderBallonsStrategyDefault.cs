//namespace Balloons.Commands
//{
//    using System.Collections.Generic;

//    using Balloons.Common;
//    using Balloons.GameRules;
//    using Balloons.FieldFactory.Field;

//    public class ReorderBallonsStrategyDefault : ReorderBalloonsStrategy
//    {
//        public override void ReorderBalloons(GameField gameField)
//        {
//            int row;
//            int col;

//            Queue<string> currentGameField = new Queue<string>();

//            for (col = 0; col < gameField.Columns; col++)
//            {
//                for (row = 0; row < gameField.Rows; row++)
//                {
//                    if (gameField[row, col] != ".")
//                    {
//                        currentGameField.Enqueue(gameField[row, col]);
//                        gameField[row, col] = ".";
//                    }
//                }

//                row = 0;
//                while (currentGameField.Count > 0)
//                {
//                    gameField[row, col] = currentGameField.Dequeue();
//                    row++;
//                }

//                currentGameField.Clear();
//            }
//        }
//    }
//}