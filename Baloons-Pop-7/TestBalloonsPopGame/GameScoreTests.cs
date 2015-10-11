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

    [TestClass]
    public class GameScoreTests
    {
        private const int MaxPossiblePlayers = 5;
        private const string PlayerNullErrorMessage = "New player cannot be null.";

        private static readonly object SyncLock = new object();

        private static ScoreBoard instance;
        private readonly IList<IPlayer> listOfPlayers;
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
        public void AddPlayer()
        {
        }

        [TestMethod]
        public void SortedPlayersByPoints()
        {


        }

        [TestMethod]
        public void IsScoreBoardIstance()
        {

        }
    }
}
