using Balloons.UI;

namespace TestBalloonsPopGame
{
    using System;
    using Balloons.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Balloons.Helpers;
    using Moq;
    using Balloons.Common.ConsoleContext;

    [TestClass]
    public class ConsoleHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ZeroLenghtPassedToCentraliseCursorMustThrowException()
        {
            ConsoleHelper.CentraliseCursor(0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NegativeLenghtPassedToCentraliseCursorMustThrowException()
        {
            ConsoleHelper.CentraliseCursor(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LenghtEqualToConsoleWidthPassedToCentraliseCursorMustThrowException()
        {
            ConsoleHelper.CentraliseCursor(Console.WindowWidth);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LenghtBiggerThanConsoleWidthPassedToCentraliseCursorMustThrowException()
        {
            ConsoleHelper.CentraliseCursor(Console.WindowWidth + 1);
        }

        [TestMethod]
        public void PassedCorrectLenghtShouldChangeCursorLeftPositionToCorrectPosition()
        {
            var textLength = 20;
            var consoleWidth = 100;
            Console.WindowWidth = consoleWidth;
            ConsoleHelper.CentraliseCursor(textLength);

            var expectedResult = consoleWidth / 2 - textLength / 2;
            var actualResult = Console.CursorLeft;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PassedCorrectLenghtShouldNotChangeCursorTop()
        {
            var textLength = 20;
            var consoleWidth = 100;
            Console.WindowWidth = consoleWidth;
            var expectedResult = Console.CursorTop;

            ConsoleHelper.CentraliseCursor(textLength);
            var actualResult = Console.CursorTop;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ConsoleForegroundColorShouldbeBlueWhenBlueBalloonColor()
        {
            var expectedColor = ConsoleColor.Blue;
            ConsoleHelper.ChangeForegroundColorDependingOnSymbol(BalloonsColors.Blue);

            var actualColor = Console.ForegroundColor;

            Assert.AreEqual(expectedColor, actualColor);
        }

        [TestMethod]
        public void ConsoleForegroundColorShouldbeWhiteWhenWhiteBalloonColor()
        {
            var expectedColor = ConsoleColor.White;
            ConsoleHelper.ChangeForegroundColorDependingOnSymbol(BalloonsColors.White);

            var actualColor = Console.ForegroundColor;

            Assert.AreEqual(expectedColor, actualColor);
        }

        [TestMethod]
        public void ConsoleForegroundColorShouldbeGreenWhenGreenBalloonColor()
        {
            var expectedColor = ConsoleColor.Green;
            ConsoleHelper.ChangeForegroundColorDependingOnSymbol(BalloonsColors.Green);

            var actualColor = Console.ForegroundColor;

            Assert.AreEqual(expectedColor, actualColor);
        }

        [TestMethod]
        public void ConsoleForegroundColorShouldbeYellowWhenYellowBalloonColor()
        {
            var expectedColor = ConsoleColor.Yellow;
            ConsoleHelper.ChangeForegroundColorDependingOnSymbol(BalloonsColors.Yellow);

            var actualColor = Console.ForegroundColor;

            Assert.AreEqual(expectedColor, actualColor);
        }

        [TestMethod]
        public void ConsoleForegroundColorShouldbeRedWhenRedBalloonColor()
        {
            var expectedColor = ConsoleColor.Red;
            ConsoleHelper.ChangeForegroundColorDependingOnSymbol(BalloonsColors.Red);

            var actualColor = Console.ForegroundColor;

            Assert.AreEqual(expectedColor, actualColor);
        }

        [TestMethod]
        public void DisplayInputErrorMessageShouldInvokeConsoleWriteLineMethod()
        {
            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;

            ConsoleHelper.DisplayInputErrorMessage("any string", writer);

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void DisplayInputErrorMessageShouldReturnConsoleForefroundColorToGray()
        {
            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;

            ConsoleHelper.DisplayInputErrorMessage("any string", writer);
            var expectedColor = ConsoleColor.Gray;
            var actualColor = Console.ForegroundColor;

            Assert.AreEqual(expectedColor, actualColor);
        }
    }
}
