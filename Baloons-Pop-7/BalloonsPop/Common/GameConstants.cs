namespace Balloons.Common
{
    public static class GameConstants
    {
        // New game constants
        public const int EasyGameFieldRows = 4;
        public const int EasyGameFieldColumns = 8;

        public const int HardGameFieldRows = 9;
        public const int HardGameFieldColumns = 10;

        // Provided game constants (old one)
        // this is used into the isFinished method (PopBalloons class) and I am not sure how to implement it without
        public const int FILLED_CELLS = HardGameFieldRows * HardGameFieldColumns;

    }
}
