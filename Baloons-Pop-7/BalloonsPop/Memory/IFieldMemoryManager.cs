namespace Balloons.Memory
{
    using Balloons.FieldFactory.Field;

    /// <summary>
    /// Interface for all classes which can store and revert game field.
    /// </summary>
    public interface IFieldMemoryManager
    {
        /// <summary>
        /// Interface for method for saving field.
        /// </summary>
        /// <param name="gameField">The field which will be saved.</param>
        void Save(IMemorable gameField);

        /// <summary>
        /// Interface for method for restoring field.
        /// </summary>
        /// <param name="gameField">Previously saved field.</param>
        void Undo(IMemorable gameField);
    }
}
