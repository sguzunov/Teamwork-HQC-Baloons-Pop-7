using System;
using Balloons.GamePlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBalloonsPopGame
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerNameWhenNotSetShouldBeDefaultName()
        {
            var player = new Player();

            Assert.AreEqual("Player", player.Name);
        }

        [TestMethod]
        public void PlayerMovesWhenNotSetShouldBeDefaultMoves()
        {
            var player = new Player();

            Assert.AreEqual(0, player.Moves);
        }

        [TestMethod]
        public void PlayerNameWhenSetShouldNotBeDefaultName()
        {
            var player = new Player("ConcretePlayer", 10);

            Assert.AreEqual("ConcretePlayer", player.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerNameCannotBeNull()
        {
            var player = new Player(null, 10);
        }

        [TestMethod]
        public void PlayerMovesWhenSetShouldNotBeDefaultMovesCount()
        {
            var player = new Player("ConcretePlayer", 10);

            Assert.AreEqual(10, player.Moves);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerMovesCannotBeNegativeCount()
        {
            var player = new Player("ConcretePlayer", -1);
        }
    }
}
