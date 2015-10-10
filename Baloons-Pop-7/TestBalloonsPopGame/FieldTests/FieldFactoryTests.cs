using System;
using Balloons.Common;
using Balloons.FieldFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBalloonsPopGame.FieldTests
{
    [TestClass]
    public class FieldFactoryTests
    {
        [TestMethod]
        public void EasyGameShouldHaveFieldWth6Rows()
        {
            var factory = new GameFieldFactory();
            var field = factory.CreateGameField(GameDifficulty.Easy);

            var expectedRows = field.Rows;

            Assert.AreEqual(6, expectedRows);
        }

        [TestMethod]
        public void EasyGameShouldHaveFieldWth6Columms()
        {
            var factory = new GameFieldFactory();
            var field = factory.CreateGameField(GameDifficulty.Easy);

            var expectedColumns = field.Columns;

            Assert.AreEqual(6, expectedColumns);
        }

        [TestMethod]
        public void HardGameShouldHaveFieldWth9Rows()
        {
            var factory = new GameFieldFactory();
            var field = factory.CreateGameField(GameDifficulty.Hard);

            var expectedRows = field.Rows;

            Assert.AreEqual(9, expectedRows);
        }

        [TestMethod]
        public void HardGameShouldHaveFieldWth9Columns()
        {
            var factory = new GameFieldFactory();
            var field = factory.CreateGameField(GameDifficulty.Hard);

            var expectedColumns = field.Columns;

            Assert.AreEqual(9, expectedColumns);
        }
    }
}
