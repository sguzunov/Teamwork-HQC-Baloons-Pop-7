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
    public class CommandManagerTests
    {
        private readonly string[] validCommands = 
        {
            "exit",
            "help",
            "save",
            "restore",
            "top",
            "pop 2 2",
        };

        private readonly string[] invalidCommands = 
        {
            "",
            "   ",
            "hello",
            "I am invalid",
            "pop",
            "pop 0 0",
            "pop -5 -5",
            "pop 80 80",
        };

        private IRenderer renderer;
        private IGameField field;
        private IFieldMemoryManager fieldMemoryManager;
        private IBalloonsFactory balloonsFactory;

        [TestInitialize]
        public void Setup()
        {
            this.renderer = new ConsoleRenderer();
            this.field = new GameField(5, 5);
            this.fieldMemoryManager = new FieldMemoryManager();
            this.balloonsFactory = new BalloonsFactory(); 
        }

        [TestMethod]
        public void ProcessCommandWithValidExitInputShouldProduceAExitCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var exit = commandManager.ProcessCommand(validCommands[0], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(exit, typeof(ExitCommand));
        }

        [TestMethod]
        public void ProcessCommandWithValidHelpInputShouldProduceAHelpCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var help = commandManager.ProcessCommand(validCommands[1], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(help, typeof(HelpCommand));
        }

        [TestMethod]
        public void ProcessCommandWithValidSaveInputShouldProduceASaveCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var save = commandManager.ProcessCommand(validCommands[2], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(save, typeof(SaveCommand));
        }

        [TestMethod]
        public void ProcessCommandWithValidRestoreInputShouldProduceARestoreCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var restore = commandManager.ProcessCommand(validCommands[3], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(restore, typeof(RestoreCommand));
        }

        [TestMethod]
        public void ProcessCommandWithValidTopInputShouldProduceATopCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var top = commandManager.ProcessCommand(validCommands[4], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(top, typeof(TopScoresCommand));
        }

        [TestMethod]
        public void ProcessCommandWithValidPopInputShouldProduceAPopCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var pop = commandManager.ProcessCommand(validCommands[5], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(pop, typeof(PopBalloonsCommand));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProcessCommandWithEmptyStringInputShouldThrow()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalid = commandManager.ProcessCommand(invalidCommands[0], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProcessCommandWithWhiteSpacesStringInputShouldThrow()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalid = commandManager.ProcessCommand(invalidCommands[1], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProcessCommandWithInvalidStringInputShouldThrow()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalid = commandManager.ProcessCommand(invalidCommands[2], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ProcessCommandWithStringWithMoreThan2WordsInputShouldThrow()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalid = commandManager.ProcessCommand(invalidCommands[3], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);
        }

        [TestMethod]
        public void ProcessCommandPopInputWithoutRowAndColShouldShouldReturnPopCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalid = commandManager.ProcessCommand(invalidCommands[4], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);
        }

        [TestMethod]
        public void ProcessCommandPop00InputShouldReturnPopCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalidPop = commandManager.ProcessCommand(invalidCommands[5], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(invalidPop, typeof(PopBalloonsCommand));
        }

        [TestMethod]
        public void ProcessCommandPopWithNegativesRowAndColInputShouldReturnPopCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalidPop = commandManager.ProcessCommand(invalidCommands[6], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(invalidPop, typeof(PopBalloonsCommand));
        }

        [TestMethod]
        public void ProcessCommandPopWithHighRowAndColInputShouldReturnPopCommand()
        {
            Setup();
            var commandManager = new CommandManager();
            var invalidPop = commandManager.ProcessCommand(invalidCommands[7], this.renderer, this.field, this.fieldMemoryManager, this.balloonsFactory);

            Assert.IsInstanceOfType(invalidPop, typeof(PopBalloonsCommand));
        }

    }
}
