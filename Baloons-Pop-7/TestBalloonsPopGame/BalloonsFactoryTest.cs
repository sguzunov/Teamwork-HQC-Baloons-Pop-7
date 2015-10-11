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
        private readonly string[] validSymbols = 
        {
            "1",
            "2",
            "3",
            "4",
            ".",
        };

        private readonly string[] invalidSymbols = 
        {
            "",
            "   ",
            "hello",            
            "80",
        };
      
        [TestMethod]
        public void GetBalloonWithBalloonOneLikeSymbolShouldRetournedBalloonOne()
        {
            var balloonFactory = new BalloonsFactory();
            Balloon balloon = balloonFactory.GetBalloon(validSymbols[0]);

            Assert.IsInstanceOfType(balloon, typeof(BalloonOne));
        }

        [TestMethod]
        public void GetBalloonWithBalloonTwoLikeSymbolShouldRetournedBalloonTwo()
        {
            var balloonFactory = new BalloonsFactory();
            Balloon balloon = balloonFactory.GetBalloon(validSymbols[1]);

            Assert.IsInstanceOfType(balloon, typeof(BalloonTwo));
        }

        [TestMethod]
        public void GetBalloonWithBalloonThreeLikeSymbolShouldRetournedBalloonThree()
        {
            var balloonFactory = new BalloonsFactory();
            Balloon balloon = balloonFactory.GetBalloon(validSymbols[2]);

            Assert.IsInstanceOfType(balloon, typeof(BalloonThree));
        }

        [TestMethod]
        public void GetBalloonWithBalloonFourLikeSymbolShouldRetournedBalloonFour()
        {
            var balloonFactory = new BalloonsFactory();
            Balloon balloon = balloonFactory.GetBalloon(validSymbols[3]);

            Assert.IsInstanceOfType(balloon, typeof(BalloonFour));
        }

        [TestMethod]
        public void GetBalloonWithBalloonPopedLikeSymbolShouldRetournedBalloonPoped()
        {
            var balloonFactory = new BalloonsFactory();
            Balloon balloon = balloonFactory.GetBalloon(validSymbols[4]);

            Assert.IsInstanceOfType(balloon, typeof(BalloonPoped));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBalloonWithInvalidSymbolEmptyStringShouldThrow()
        {
            var balloon = new BalloonsFactory();
            balloon.GetBalloon(invalidSymbols[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBalloonWithInvalidSymbolWhiteSpacesShouldThrow()
        {
            var balloon = new BalloonsFactory();
            balloon.GetBalloon(invalidSymbols[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBalloonWithInvalidSymbolStringShouldThrow()
        {
            var balloon = new BalloonsFactory();
            balloon.GetBalloon(invalidSymbols[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBalloonWithInvalidSymbol80ShouldThrow()
        {
            var balloon = new BalloonsFactory();
            balloon.GetBalloon(invalidSymbols[3]);
        }
    }
}
