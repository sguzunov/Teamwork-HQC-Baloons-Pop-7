namespace TestBalloonsPopGame
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Balloons.Common;
    using Balloons.FieldFactory.Field;
    using Balloons.InputHandler;


    [TestClass]
    public class ConsoleInputHandlerTest
    {
        private readonly string[] validGameModes = { "fly", "default" };
        private readonly string[] validGameDifficulties = { "easy", "hard" };
        private readonly string[] validGameAnswers = { "yes", "no" };

        private readonly string[] validInputCommands = { "help", "start", "exit" };

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
            var input = "228";
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

        [TestMethod]
        public void IsValidInputShouldReturnTrueIfTheInputIsAString()
        {
            var inputHandler = new ConsoleInputHandler();
            string input = "hello";
            bool validInut = inputHandler.IsValidInput(input);

            Assert.AreEqual(true, validInut);
        }

        [TestMethod]
        public void IsValidInputShouldReturnFalseIfTheInputIsAnEmptyString()
        {
            var inputHandler = new ConsoleInputHandler();
            string input = string.Empty;
            bool validInut = inputHandler.IsValidInput(input);

            Assert.AreEqual(false, validInut);
        }

        [TestMethod]
        public void IsValidInputShouldReturnFalseIfTheInputIsAStringWithOnlyWhiteSpaces()
        {
            var inputHandler = new ConsoleInputHandler();
            string input = "   ";
            bool validInut = inputHandler.IsValidInput(input);

            Assert.AreEqual(false, validInut);
        }

        [TestMethod]
        public void IsPositionValidShouldRetournTrueWithAValidPosition()
        {
            var field = new GameField(5, 5);
            var inputHandler = new ConsoleInputHandler();

            var result = inputHandler.IsPositionValid(2, 2, field);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsPositionValidShouldRetournFalseWithNegativeRow()
        {
            var field = new GameField(5, 5);
            var inputHandler = new ConsoleInputHandler();

            var result = inputHandler.IsPositionValid(-2, 2, field);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPositionValidShouldRetournFalseWithNegativeCol()
        {
            var field = new GameField(5, 5);
            var inputHandler = new ConsoleInputHandler();

            var result = inputHandler.IsPositionValid(2, -2, field);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPositionValidShouldRetournFalseWithNegativesRowAndCol()
        {
            var field = new GameField(5, 5);
            var inputHandler = new ConsoleInputHandler();

            var result = inputHandler.IsPositionValid(-2, -2, field);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPositionValidShouldRetournFalseWithRowGreaterThanFieldRows()
        {
            var field = new GameField(5, 5);
            var inputHandler = new ConsoleInputHandler();

            var result = inputHandler.IsPositionValid(8, 2, field);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPositionValidShouldRetournFalseWithColGreaterThanFieldCols()
        {
            var field = new GameField(5, 5);
            var inputHandler = new ConsoleInputHandler();

            var result = inputHandler.IsPositionValid(2, 8, field);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPositionValidShouldRetournFalseWithColGreaterThanFieldColsAndRowsGreaterThanFieldRols()
        {
            var field = new GameField(5, 5);
            var inputHandler = new ConsoleInputHandler();

            var result = inputHandler.IsPositionValid(8, 8, field);

            Assert.AreEqual(false, result);
        }
    }
}
