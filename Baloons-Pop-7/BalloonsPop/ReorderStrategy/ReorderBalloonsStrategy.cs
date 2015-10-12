namespace Balloons.ReorderStrategy
{
    using Balloons.FieldFactory.Field;

    /// <summary>
    /// Provides an abstract interface for all reorder strategies.
    /// </summary>
    public abstract class ReorderBalloonsStrategy
    {
        /// <summary>
        /// Abstract interface of a method for reordering matrix.
        /// </summary>
        /// <param name="gameField">The field which will be reordered.</param>
        public abstract void ReorderBalloons(IGameField gameField);
    }
}
