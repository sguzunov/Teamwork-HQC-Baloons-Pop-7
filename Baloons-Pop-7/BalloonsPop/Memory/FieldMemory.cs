namespace Balloons.Memory
{
    using Balloons.Cell;

    public class FieldMemory
    {
        private Balloon[,] fieldMatrix;

        public FieldMemory(Balloon[,] fieldMatrix)
        {
            this.fieldMatrix = fieldMatrix;
        }

        public Balloon[,] GetMemento()
        {
            var savedFieldMatrix = (Balloon[,])this.fieldMatrix.Clone();
            return savedFieldMatrix;
        }
    }
}
