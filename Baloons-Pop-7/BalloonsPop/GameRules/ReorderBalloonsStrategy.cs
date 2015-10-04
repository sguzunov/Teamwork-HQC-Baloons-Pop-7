namespace Balloons.GameRules
{
    using Balloons.FieldFactory.Field;

    public abstract class ReorderBalloonsStrategy
    {
        public abstract void ReorderBalloons(IGameField gameField);
    }
}
