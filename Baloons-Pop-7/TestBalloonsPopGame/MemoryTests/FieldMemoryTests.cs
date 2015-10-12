namespace TestBalloonsPopGame.MemoryTests
{
    using Balloons.Cell;
    using Balloons.Memory;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FieldMemoryTests
    {
        private readonly Balloon[,] filledMatrix =
        {
            {new BalloonOne(),new BalloonOne()},
            {new BalloonOne(),new BalloonOne()},
        };

        [TestMethod]
        public void GetMementoShouldReturnEmplpyMatrixWhenSuchPassed()
        {
            var matrix = new Balloon[2, 2];
            var memory = new FieldMemory(matrix);
            var savedMatrix = memory.GetMemento();

            var expectedResult = true;
            for (int i = 0; i < savedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < savedMatrix.GetLength(1); j++)
                {
                    if (savedMatrix[i, i] != null)
                    {
                        expectedResult = false;
                    }
                }
            }

            Assert.IsTrue(expectedResult);
        }

        [TestMethod]
        public void GetMementoShouldReturnNonEmptyMatrixWhenSuchPassed()
        {
            var memory = new FieldMemory(filledMatrix);
            var savedMatrix = memory.GetMemento();

            var expectedResult = true;
            for (int i = 0; i < savedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < savedMatrix.GetLength(1); j++)
                {
                    if (savedMatrix[i, i] == null)
                    {
                        expectedResult = false;
                    }
                }
            }

            Assert.IsTrue(expectedResult);
        }

        [TestMethod]
        public void GetMementoShouldReturnDifferentInstanceOfMatrix()
        {
            var memory = new FieldMemory(filledMatrix);
            var savedMatrix = memory.GetMemento();

            Assert.AreNotSame(filledMatrix, savedMatrix);
        }
    }
}
