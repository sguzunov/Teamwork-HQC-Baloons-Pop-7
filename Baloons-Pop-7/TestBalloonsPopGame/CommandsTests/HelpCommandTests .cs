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
    public class HelpCommandTests
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
        public void HelpCommandShouldExecute()
        {
            var helpC = new HelpCommand(this.renderer);
            helpC.Execute();
        }


        [TestMethod]
        public void SaveCommandShouldExecute()
        {
            var saveC = new SaveCommand(this.fieldMemoryManager, this.field);
            saveC.Execute();
        }

        [TestMethod]
        public void RestoreCommandShouldExecute()
        {
            Setup();
            this.fieldMemoryManager.Save(this.field);
            var restoreC = new RestoreCommand(this.fieldMemoryManager, this.field);
            restoreC.Execute();
        }

        [TestMethod]
        public void TopScoresCommandShouldExecute()
        {
            var topC = new TopScoresCommand(this.renderer);
            topC.Execute();
        }

        //[TestMethod]
        //public void ExitCommandShouldExecute()
        //{
        //    var exitC = new ExitCommand(this.renderer);
        //    exitC.Execute();
        //}

    }
}
