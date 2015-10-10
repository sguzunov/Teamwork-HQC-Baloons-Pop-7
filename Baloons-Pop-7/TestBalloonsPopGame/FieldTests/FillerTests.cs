using System;
using Balloons.Cell;
using Balloons.FieldFactory.Field;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestBalloonsPopGame.FieldTests
{
    [TestClass]
    public class FillerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassingNullToFillMethodShouldThrowException()
        {
            var mock = new Mock<IFiller>();
            mock.Setup(f => f.Fill(null)).Throws(new ArgumentNullException());

            var filler = mock.Object;
            filler.Fill(null);
        }

        [TestMethod]
        public void PassingMatrixToFillMethodShouldNotThrowException()
        {
            var mock = new Mock<IFiller>();
            var matrix = new Balloon[6, 6];
            mock.Setup(f => f.Fill(new Balloon[5, 5])).Verifiable();

            var filler = mock.Object;
            filler.Fill(matrix);
        }

        [TestMethod]
        public void PassingEmptyMatrixToFillMethodShouldNotBeEmptyAfterThat()
        {
            var matrix = new Balloon[5, 5];
            var filler = new Filler(new BalloonsFactory());

            filler.Fill(matrix);

            Assert.IsNotNull(matrix[1, 1]);
        }
    }
}
