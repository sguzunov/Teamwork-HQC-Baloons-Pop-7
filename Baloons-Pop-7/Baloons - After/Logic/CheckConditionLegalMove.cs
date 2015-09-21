namespace Baloons.Logic
{
    using Common;

    class CheckConditionLegalMove
    {
        internal static bool IsLegalMove(int i, int j)
        {
            if ((i < 0) || (j < 0) || (j > GameConstants.HEIGHT - 1) || (i > GameConstants.WIDTH - 1))
            {
                return false;
            }

            else
            {
                return (GameField.gameField[i, j] != ".");
            }
        }
    }
}
