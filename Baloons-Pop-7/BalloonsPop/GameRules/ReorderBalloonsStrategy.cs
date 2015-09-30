namespace Balloons.GameRules
{
    using Balloons.GameField;

    public abstract class ReorderBalloonsStrategy
    {
        public abstract void ReorderBalloons(GameField gameField);
    }
}
