namespace TestBalloonsPopGame
{
    using Balloons.GamePlayer;
    using Balloons.GameScore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class GameScoreTests
    {
        public Player player;

        [TestMethod]
        public void PlayerIsNull()
        {
            Assert.IsNull(player);
        }

        [TestMethod]
        public void PlayerIsNotNull()
        {
            var realPlayer = new Player();
            realPlayer.Name = "Pesho";
            realPlayer.Moves = 23;
            Assert.IsNotNull(realPlayer);
        }

        [TestMethod]
        public void AddPlayerInListOfGameScoreBoardTest()
        {
            var instanceScoreBoard = ScoreBoard.Instance;
            instanceScoreBoard.AddPlayer(new Player());
            Assert.IsNotNull(instanceScoreBoard);
        }

        [TestMethod]
        public void GetSortedPlayersByMovesTest()
        {
            var randomGenerator = new Random();
            var randomNum = randomGenerator.Next(1, 100);
            var player1 = new Player("Pesho", randomNum);
            var player2 = new Player("Stamat", randomNum);
            var scoreBoard = ScoreBoard.Instance;
            scoreBoard.AddPlayer(player1);
            scoreBoard.AddPlayer(player2);
            var sortedPlayer = scoreBoard.GetSortedPlayers;
            for (int i = 0; i < sortedPlayer.Count - 1; i++)
            {
                Assert.IsTrue((sortedPlayer[i].Moves <= sortedPlayer[i + 1].Moves));
            }
        }

        [TestMethod]
        public void ScoreBoardIsSingle()
        {
            var instance1 = ScoreBoard.Instance;
            var instance2 = ScoreBoard.Instance;
            Assert.AreSame(instance1, instance2);
        }
    }
}
