//namespace Balloons.GameRules
//{
//    using Balloons.Common;
//    using Balloons.FieldFactory;
//    using Balloons.FieldFactory.Field;

//    public class PopBalloons
//    {
//        private static int clearedCells = 0;
//        public static  int filledCells = GameConstants.FILLED_CELLS;

       
//        // this method should be renamed to Pop???
//        internal static void Pop(int row, int col, string activeCell, GameField field)
//        {
//            bool validPop = IsPopValid(row, field.Rows) && IsPopValid(col, field.Columns);

//            if (validPop && (field[row, col] == activeCell))
//            {
//                field[row, col] = ".";
//                clearedCells++;

//                Pop(row - 1, col, activeCell, field); // Up
//                Pop(row + 1, col, activeCell, field); // Down
//                Pop(row, col + 1, activeCell, field); // Left
//                Pop(row, col - 1, activeCell, field); // Right
//            }
//            else
//            {
//                filledCells -= clearedCells;
//                clearedCells = 0;
//                return;
//            }
//        }

//        internal static bool IsPopValid(int index, int boundValue)
//        {
//            if ((index >= 0) && (index < boundValue))
//            {                
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        // this method should be remved from here
//        internal static bool IsFinished()
//        {
//            if (filledCells == 0)
//            {
//                filledCells = GameConstants.FILLED_CELLS;
//                return true;                
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }
//}
