namespace TestBalloonsPopGame
{
    using Balloons.Cell;
    using Balloons.Commands;
    using Balloons.FieldFactory.Field;
    using Balloons.GameEngine;
    using Balloons.InputHandler;
    using Balloons.Memory;
    using Balloons.ReorderStrategy;
    using Balloons.UI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using Balloons.Common.ConsoleContext;

    [TestClass]
    public class GameEngineTests
    {
        private readonly GameEngineContext engineContext = new GameEngineContext();
        private BalloonsGameEngine engine = new BalloonsGameEngine();
        //private ReorderBalloonsStrategy strategy;
        private IRenderer renderer = new ConsoleRenderer();

        [TestInitialize]
        public void Setup()
        {
            this.engine.FieldFactory(engineContext.FieldFactory);
            this.engine.BalloonsFactory(engineContext.BalloonsFactory);
            this.engine.CommandManager(engineContext.CommandManager);
            this.engine.FieldMemoryManager(engineContext.FieldMemoryManager);
            this.engine.GameFieldFiller(engineContext.GameFieldFiller);
            this.engine.Input(engineContext.Input);
            //this.engine.ReorderBalloonsStrategy(strategy);
            this.engine.Renderer(renderer);
        }

        // I'm not sure why this throw an exception
        //[TestMethod]
        //public void a()
        //{
        //    Setup();
        //    var mockConsole = new Mock<IConsoleReader>();
        //    var reader = mockConsole.Object;
        //    var writer = new ConsoleWriter();

        //    mockConsole.Setup(c => c.ReadLine()).Returns("top");
        //    engineContext.Input = new ConsoleInputHandler(writer, reader);
        //    engine.StartGame();
        //}
    }
}
