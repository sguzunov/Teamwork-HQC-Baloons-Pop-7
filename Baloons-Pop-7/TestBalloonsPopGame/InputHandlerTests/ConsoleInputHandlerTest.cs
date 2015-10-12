namespace TestBalloonsPopGame
{
    using Balloons.Common;
    using Balloons.Common.ConsoleContext;
    using Balloons.InputHandler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ConsoleInputHandlerTest
    {
        private readonly string[] validGameModes = { "fly", "default" };
        private readonly string[] validGameDifficulties = { "easy", "hard" };
        private readonly string[] validGameAnswers = { "yes", "no" };

        private readonly string[] validInputCommands = { "help", "start", "exit" };

        [TestMethod]
        public void GetGameModeShuldCallConsoleMethodReadLineOnceWithValidInputFly()
        {
            var mockConsole = new Mock<IConsoleReader>();
            var reader = mockConsole.Object;
            var writer = new ConsoleWriter();

            mockConsole.Setup(c => c.ReadLine()).Returns("fly");
            var inputHandler = new ConsoleInputHandler(writer, reader);
            inputHandler.GetGameMode();

            mockConsole.Verify(c => c.ReadLine(), Times.Exactly(1));
        }

        [TestMethod]
        public void GetGameModeShuldCallConsoleMethodReadLineOnceWithValidInputDefault()
        {
            var mockConsole = new Mock<IConsoleReader>();
            var reader = mockConsole.Object;
            var writer = new ConsoleWriter();

            mockConsole.Setup(c => c.ReadLine()).Returns("Default");
            var inputHandler = new ConsoleInputHandler(writer, reader);
            inputHandler.GetGameMode();

            mockConsole.Verify(c => c.ReadLine(), Times.Exactly(1));
        }

        [TestMethod]
        public void GetGameDifficultyShouldCallConsoleMethodReadLineOnceWithValidInput()
        {
            var mockConsole = new Mock<IConsoleReader>();
            var reader = mockConsole.Object;
            var writer = new ConsoleWriter();

            mockConsole.Setup(c => c.ReadLine()).Returns("easy");
            var inputHandler = new ConsoleInputHandler(writer, reader);
            inputHandler.GetGameDifficulty();

            mockConsole.Verify(c => c.ReadLine(), Times.Exactly(1));
        }

        [TestMethod]
        public void GetAnswerShouldCallConsoleMethodReadLineOnceWithValidInput()
        {
            var mockConsole = new Mock<IConsoleReader>();
            var reader = mockConsole.Object;
            var writer = new ConsoleWriter();

            mockConsole.Setup(c => c.ReadLine()).Returns("yes");
            var inputHandler = new ConsoleInputHandler(writer, reader);
            inputHandler.GetPlayAgainResponse();

            mockConsole.Verify(c => c.ReadLine(), Times.Exactly(1));
        }

        [TestMethod]
        public void ReadInputCallConsoleMethodReadLineOnce()
        {
            var mockConsole = new Mock<IConsoleReader>();
            var reader = mockConsole.Object;
            var mockConsoleW = new Mock<IConsoleWriter>();
            var writer = mockConsoleW.Object;

            mockConsoleW.Setup(c => c.WriteLine(It.IsAny<string>()));
            mockConsole.Setup(c => c.ReadLine()).Returns("top");
            var inputHandler = new ConsoleInputHandler(writer, reader);
            inputHandler.ReadInputCommand();

            mockConsole.Verify(c => c.ReadLine(), Times.Exactly(1));
        }

        [TestMethod]
        public void ReadPlayerInfoCallConsoleMethodReadLineOnce()
        {
            var mockConsole = new Mock<IConsoleReader>();
            var reader = mockConsole.Object;
            var mockConsoleW = new Mock<IConsoleWriter>();
            var writer = mockConsoleW.Object;

            mockConsoleW.Setup(c => c.WriteLine(It.IsAny<string>()));
            mockConsole.Setup(c => c.ReadLine()).Returns("Pesho");
            var inputHandler = new ConsoleInputHandler(writer, reader);
            inputHandler.ReadPlayerInfo();

            mockConsole.Verify(c => c.ReadLine(), Times.Exactly(1));
        }

        [TestMethod]
        public void ValidGameModeFlyShouldReturnTrue()
        {
            var input = validGameModes[0];
            var result = Validator.CheckIfValidGameMode(input);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidGameModeDefaulttShouldReturnTrue()
        {
            var input = validGameModes[1];
            var result = Validator.CheckIfValidGameMode(input);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void InvalidGameModeStringShouldReturnFalse()
        {
            var input = "invalid";
            var result = Validator.CheckIfValidGameMode(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidGameModeNumericShouldReturnFalse()
        {
            var input = "228 invalid s";
            var result = Validator.CheckIfValidGameMode(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidGameModeEmptyStringShouldReturnFalse()
        {
            var input = string.Empty;
            var result = Validator.CheckIfValidGameMode(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidGameModeWhiteSpacesShouldReturnFalse()
        {
            var input = "      ";
            var result = Validator.CheckIfValidGameMode(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidGameDifficultyEasyShouldReturnTrue()
        {
            var input = validGameDifficulties[0];
            var result = Validator.CheckIfValidGameDifficulty(input);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidGameDifficultyHardShouldReturnTrue()
        {
            var input = validGameDifficulties[1];
            var result = Validator.CheckIfValidGameDifficulty(input);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void InvalidGameDifficultyStringShouldReturnFalse()
        {
            var input = "invalid";
            var result = Validator.CheckIfValidGameDifficulty(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidGameDifficultyNumericShouldReturnFalse()
        {
            var input = "228";
            var result = Validator.CheckIfValidGameDifficulty(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidGameDifficultyEmptyStringShouldReturnFalse()
        {
            var input = string.Empty;
            var result = Validator.CheckIfValidGameDifficulty(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidGameDifficultyWhiteSpacesShouldReturnFalse()
        {
            var input = "      ";
            var result = Validator.CheckIfValidGameDifficulty(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ValidPlayAgainAnswerEasyShouldReturnTrue()
        {
            var input = validGameAnswers[0];
            var result = Validator.CheckIfValidAnswer(input);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidPlayAgainAnswerHardShouldReturnTrue()
        {
            var input = validGameAnswers[1];
            var result = Validator.CheckIfValidAnswer(input);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void InvalidPlayAgainAnswerStringShouldReturnFalse()
        {
            var input = "invalid";
            var result = Validator.CheckIfValidAnswer(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidPlayAgainAnswerNumericShouldReturnFalse()
        {
            var input = "228";
            var result = Validator.CheckIfValidAnswer(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidPlayAgainAnswerEmptyStringShouldReturnFalse()
        {
            var input = string.Empty;
            var result = Validator.CheckIfValidAnswer(input);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void InvalidPlayAgainAnswerWhiteSpacesShouldReturnFalse()
        {
            var input = "      ";
            var result = Validator.CheckIfValidAnswer(input);
            Assert.AreEqual(false, result);
        }
    }
}
