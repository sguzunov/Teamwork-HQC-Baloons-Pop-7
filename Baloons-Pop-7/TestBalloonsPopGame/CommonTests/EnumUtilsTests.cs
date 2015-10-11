namespace TestBalloonsPopGame
{
    using Balloons.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class EnumUtilsTest
    {
        private readonly string[] validGameModes = { "fly", "default" };
        private readonly string[] validGameDifficulties = { "easy", "hard" };
        private readonly string[] validGameAnswers = { "yes", "no" };

        [TestMethod]
        public void GetGameModeFromStringWorkProperlyFly()
        {
            var result = EnumUtils.GetGameModeFromString(validGameModes[0]);
            Assert.AreEqual(result, GameMode.Fly);
        }

        [TestMethod]
        public void GetGameModeFromStringWorkProperlyDefault()
        {
            var result = EnumUtils.GetGameModeFromString(validGameModes[1]);
            Assert.AreEqual(result, GameMode.Default);
        }

        [TestMethod]
        public void GetGameDifficultyFromStringWorkProperlyEasy()
        {
            var result = EnumUtils.GetGameDifficultyFromString(validGameDifficulties[0]);
            Assert.AreEqual(result, GameDifficulty.Easy);
        }

        [TestMethod]
        public void GetGameDifficultyFromStringWorkProperlyHard()
        {
            var result = EnumUtils.GetGameDifficultyFromString(validGameDifficulties[1]);
            Assert.AreEqual(result, GameDifficulty.Hard);
        }

        [TestMethod]
        public void GetGameAnswerFromStringWorkProperlyYes()
        {
            var result = EnumUtils.GetPlayAgainAnswerFromString(validGameAnswers[0]);
            Assert.AreEqual(result, AnotherRound.Yes);
        }

        [TestMethod]
        public void GetGameAnswerFromStringWorkProperlyNo()
        {
            var result = EnumUtils.GetPlayAgainAnswerFromString(validGameAnswers[1]);
            Assert.AreEqual(result, AnotherRound.No);
        }
    }
}
