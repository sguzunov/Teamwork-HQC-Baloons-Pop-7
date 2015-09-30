namespace Balloons.Logic
{
    using Balloons.Common;
    using Balloons.GameField;

    class CheckConditionLegalMove
    {
        internal static bool IsLegalMove(int i, int j, GameField gameField)
        {
            if ((i < 0) || (j < 0) || (j > gameField.Rows - 1) || (i > gameField.Columns - 1))
            {
                return false;
            }

            else
            {
                return (gameField[i, j] != ".");
            }
        }
    }
}
