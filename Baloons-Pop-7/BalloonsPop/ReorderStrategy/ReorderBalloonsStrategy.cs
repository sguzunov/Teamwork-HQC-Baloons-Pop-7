namespace Balloons.ReorderStrategy
{
    using Balloons.FieldFactory.Field;

    public abstract class ReorderBalloonsStrategy
    {
        public abstract void ReorderBalloons(IGameField gameField);
    }
}
