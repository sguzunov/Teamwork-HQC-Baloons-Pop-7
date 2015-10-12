namespace Balloons.Memory
{
    using Balloons.Cell;

    /// <summary>
    /// Class which knows how to save game field matrix.
    /// </summary>
    public class FieldMemory
    {
        private Balloon[,] fieldMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldMemory"/> class.
        /// </summary>
        /// <param name="fieldMatrix">Field which has to be saved.</param>
        public FieldMemory(Balloon[,] fieldMatrix)
        {
            this.fieldMatrix = fieldMatrix;
        }

        /// <summary>
        /// Provides access to the previously saved matrix.
        /// </summary>
        /// <returns>Restored matrix.</returns>
        public Balloon[,] GetMemento()
        {
            var savedFieldMatrix = (Balloon[,])this.fieldMatrix.Clone();
            return savedFieldMatrix;
        }
    }
}
