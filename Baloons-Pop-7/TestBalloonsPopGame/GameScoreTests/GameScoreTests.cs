namespace TestBalloonsPopGame
{
    using Balloons.GamePlayer;
    using Balloons.GameScore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;

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
        public void AddPlayerInListTest()
        {
            var instanceScoreBoard = ScoreBoard.Instance;
            instanceScoreBoard.AddPlayer(new Player());
            Assert.IsNotNull(instanceScoreBoard);
        }

        [TestMethod]
        public void GetSortedPlayersByPointsTest()
        {


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
