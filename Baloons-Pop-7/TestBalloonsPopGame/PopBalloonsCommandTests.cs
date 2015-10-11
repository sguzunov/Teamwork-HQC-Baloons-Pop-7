namespace TestBalloonsPopGame
{
    using Balloons.Cell;
    using Balloons.Commands;
    using Balloons.FieldFactory.Field;
    using Balloons.Memory;
    using Balloons.UI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class PopBalloonsCommandTests
    {
        private IRenderer renderer;
        private IGameField field;
        private IFieldMemoryManager fieldMemoryManager;
        private IBalloonsFactory balloonsFactory;

        [TestInitialize]
        public void Setup()
        {
            this.renderer = new ConsoleRenderer();
            this.field = new GameField(2, 2);
            this.fieldMemoryManager = new FieldMemoryManager();
            this.balloonsFactory = new BalloonsFactory();
            this.field[0, 0] = new BalloonOne();
            this.field[0, 1] = new BalloonTwo();
            this.field[1, 0] = new BalloonThree();
            this.field[1, 1] = new BalloonFour();
        }
        [TestMethod]
        public void PopBallonsCommandShouldWorkProperlyWithValidInput()
        {
            Setup();
            var originalField = new GameField(2, 2);
            originalField[0, 0] = new BalloonOne();
            originalField[0, 1] = new BalloonTwo();
            originalField[1, 0] = new BalloonThree();
            originalField[1, 1] = new BalloonFour();
            var popC = new PopBalloonsCommand(this.balloonsFactory, this.field, 1, 1);
            popC.Execute();

            Assert.AreNotEqual(field, originalField);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PopBallonsCommandShouldThrowWithInvalidInput()
        {
            Setup();
            var originalField = new GameField(2, 2);
            originalField[0, 0] = new BalloonOne();
            originalField[0, 1] = new BalloonTwo();
            originalField[1, 0] = new BalloonThree();
            originalField[1, 1] = new BalloonFour();
            var popC = new PopBalloonsCommand(this.balloonsFactory, this.field, 10, 10);
            popC.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PopBallonsCommandThrowWithNegativeInput()
        {
            Setup();
            var originalField = new GameField(2, 2);
            originalField[0, 0] = new BalloonOne();
            originalField[0, 1] = new BalloonTwo();
            originalField[1, 0] = new BalloonThree();
            originalField[1, 1] = new BalloonFour();
            var popC = new PopBalloonsCommand(this.balloonsFactory, this.field, -2, -2);
            popC.Execute();
        }
    }
}
