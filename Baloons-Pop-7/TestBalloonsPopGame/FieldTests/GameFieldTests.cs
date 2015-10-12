namespace TestBalloonsPopGame
{
    using System;

    using Balloons.Cell;
    using Balloons.FieldFactory.Field;
    using Balloons.Memory;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class GameFieldTests
    {
        private const int FieldValidRows = 4;
        private const int FieldValidColumns = 4;

        // Testing rows and columns
        [TestMethod]
        public void GameFieldCreatedWith4RowsShouldHave4Rows()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var actualRows = field.Rows;

            Assert.AreEqual(4, actualRows);
        }

        [TestMethod]
        public void GameFieldCreatedWith4ColumnsShouldHave4Columns()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var actualColumns = field.Columns;

            Assert.AreEqual(4, actualColumns);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GameFieldCreatedWithNegativeCountRowsShouldThrowException()
        {
            var field = new GameField(-2, FieldValidColumns);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GameFieldCreatedWithNegativeCountColumnsShouldThrowException()
        {
            var field = new GameField(FieldValidRows, -5);
        }

        // Testing field filler
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GameFieldShouldThrowWhenExceptionWhenNullFillerPassed()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field.Filler = null;
        }

        [TestMethod]
        public void GameFieldFillerWhenNotPassedShouldBeNull()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            Assert.IsNull(field.Filler);
        }
        //
        [TestMethod]
        public void GameFieldFillerShouldNotBeNullWhenPassed()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);
            var filler = new Filler(new BalloonsFactory());

            field.Filler = filler;
            var actualFiller = field.Filler;

            Assert.IsNotNull(actualFiller);
        }

        // Testing field indexer
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GettingNegativeRowFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var expectedBalloon = field[-1, FieldValidColumns];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GettingRowBiggerThanRowsCountFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var expectedBalloon = field[5, FieldValidColumns];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GettingNegativeColumnFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var expectedBalloon = field[FieldValidRows, -1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GettingColumnBiggerThanColumnsCountFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var expectedBalloon = field[FieldValidRows, 5];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SettingOnNegativeRowFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[-2, FieldValidColumns] = new BalloonOne();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SettingOnRowBiggerThanRowsCountFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[5, FieldValidColumns] = new BalloonOne();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SettingOnNegativeColumnFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[FieldValidRows, -1] = new BalloonOne();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SettingOnColumnBiggerThanColumnsCountFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[FieldValidRows, 5] = new BalloonOne();
        }

        [TestMethod]
        public void NotFilledGameFieldShouldReturnNullBalloon()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var balloon = field[1, 1];

            Assert.IsNull(balloon);
        }

        [TestMethod]
        public void FilledGameFieldPositionShouldReturnBalloon()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[1, 1] = new BalloonOne();
            var balloon = field[1, 1];

            Assert.IsNotNull(balloon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SettingNullBalloonToGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[1, 1] = null;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SettingBallonOnWrongRowAndColumnShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[-1, -1] = new BalloonOne();
        }

        // Testing Fill() method
        [TestMethod]
        public void FillMethodShouldDoNothingWhenInvoked()
        {
            var mock = new Mock<IGameField>();
            mock.Setup(f => f.Fill()).Verifiable();

            var field = mock.Object;
            field.Fill();
        }

        [TestMethod]
        public void FillMethodShouldFillGmaeFieldWithBalloons()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);
            var filler = new Filler(new BalloonsFactory());
            field.Filler = filler;

            field.Fill();
            var balloon = field[1, 1];

            Assert.IsInstanceOfType(balloon, typeof(Balloon));
        }

        // Testing SaveField()
        [TestMethod]
        public void SaveFieldMethodShouldReturnFieldMemoryObject()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);
            var saveField = field.SaveField();

            Assert.IsInstanceOfType(saveField, typeof(FieldMemory));
        }

        // Testing RestoreField()
        [TestMethod]
        public void GameFieldShouldHaveTheSameMatrixAsRestored()
        {
            var mockField = new Mock<IGameField>();
            mockField.Setup(f => f.RestoreField(It.IsAny<FieldMemory>()))
                .Verifiable();

            var field = mockField.Object;

            field.RestoreField(new FieldMemory(new Balloon[FieldValidRows, FieldValidColumns]));
        }
    }
}
