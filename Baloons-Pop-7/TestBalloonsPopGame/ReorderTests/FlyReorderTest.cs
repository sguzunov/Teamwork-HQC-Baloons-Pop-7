namespace TestBalloonsPopGame.ReoerderTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Balloons.Cell;
    using Balloons.FieldFactory.Field;
    using Balloons.ReorderStrategy;

    [TestClass]
    public class FlyReorderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PassingNullGameFieldShouldThrowException()
        {
            var strategy = new ReorderBalloonsStrategyFly();

            strategy.ReorderBalloons(null);
        }

        [TestMethod]
        public void GameFieldHavingCellsWithNumbersIsNotReordered()
        {
            var strategy = new ReorderBalloonsStrategyFly();
            var field = new GameField(2, 2);
            field[0, 0] = new BalloonOne();
            field[0, 1] = new BalloonTwo();
            field[1, 0] = new BalloonThree();
            field[1, 1] = new BalloonFour();

            strategy.ReorderBalloons(field);
            var isChanged = false;
            int nextSymbol = 0;

            for (int i = 0; i < field.Rows; i++)
            {
                for (int j = 0; j < field.Columns; j++)
                {
                    nextSymbol++;
                    if (field[i, j].Symbol != nextSymbol.ToString())
                    {
                        isChanged = true;
                    }
                }
            }

            Assert.IsFalse(isChanged);
        }

        [TestMethod]
        public void TwoDimensionalGameFieldWithFirstCellHavingSymbolDotIsMovedAtBottom()
        {
            var strategy = new ReorderBalloonsStrategyFly();
            var field = new GameField(2, 2);
            field[0, 0] = new BalloonPoped();
            field[0, 1] = new BalloonTwo();
            field[1, 0] = new BalloonThree();
            field[1, 1] = new BalloonFour();

            strategy.ReorderBalloons(field);

            Assert.IsInstanceOfType(field[1, 0], typeof(BalloonPoped));
        }

        [TestMethod]
        public void TwoDimensionalGameFieldWithCellAtBottomHavingSymbolDotIsNotMoved()
        {
            var strategy = new ReorderBalloonsStrategyFly();
            var field = new GameField(2, 2);
            field[0, 0] = new BalloonOne();
            field[0, 1] = new BalloonTwo();
            field[1, 0] = new BalloonPoped();
            field[1, 1] = new BalloonFour();

            strategy.ReorderBalloons(field);

            Assert.IsInstanceOfType(field[1, 0], typeof(BalloonPoped));
        }
    }
}
