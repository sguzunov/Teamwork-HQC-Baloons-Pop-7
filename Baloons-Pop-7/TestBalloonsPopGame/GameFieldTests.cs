using System;
using System.Runtime.InteropServices;
using Balloons.Cell;
using Balloons.FieldFactory.Field;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBalloonsPopGame
{
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
            var filler = new Filler(new BalloonsFactory());

            field.Filler = filler;
            field.Fill();

            var expectedBalloon = field[-1, FieldValidColumns];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GettingNegativeColumnFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);
            var filler = new Filler(new BalloonsFactory());

            field.Filler = filler;
            field.Fill();

            var expectedBalloon = field[FieldValidRows, -1];
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
        public void SettingOnNegativeColumnFromGameFieldShouldThrowException()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            field[FieldValidRows, -1] = new BalloonOne();
        }

        [TestMethod]
        public void NotFilledGameFieldShouldReturnNullBalloon()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);

            var balloon = field[1, 1];

            Assert.IsNull(balloon);
        }

        [TestMethod]
        public void FilledGameFieldShouldReturnNotNullBalloon()
        {
            var field = new GameField(FieldValidRows, FieldValidColumns);
            var filler = new Filler(new BalloonsFactory());
            field.Filler = filler;

            field.Fill();
            var balloon = field[1, 1];

            Assert.IsNotNull(balloon);
        }
    }
}
