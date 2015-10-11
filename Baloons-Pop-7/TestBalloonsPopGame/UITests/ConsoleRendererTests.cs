using System;
using Balloons.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestBalloonsPopGame.UITests
{
    [TestClass]
    public class ConsoleRendererTests
    {
        private const string TestMessage = "TestMessage";

        [TestMethod]
        public void RenderGameMessageShuldCallConsoleMethodWriteLineOnce()
        {
            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;
            var renderer = new ConsoleRenderer(writer);

            renderer.RenderGameMessage(TestMessage);

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void RenderGameMessageShuldChangeCursorColumnPosition()
        {
            var renderer = new ConsoleRenderer();

            renderer.RenderGameMessage(TestMessage);
            var expectedCursorPosition = Console.WindowWidth / 2 - TestMessage.Length / 2;
            var actualCursorPosition = Console.CursorLeft;

            Assert.AreEqual(expectedCursorPosition, actualCursorPosition);
        }

        [TestMethod]
        public void RenderCommandsWithPassedOneCommandStringShouldCallConsoleWriteLineOnce()
        {
            string[] commands = { "command" };
            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;
            var renderer = new ConsoleRenderer(writer);

            renderer.RenderCommands(commands);

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void RenderCommandsWithPassedFiveCommandStringsShouldCallConsoleWriteLineFiveTimes()
        {
            string[] commands =
            {
                "command1",
                "command2",
                "command3",
                "command4",
                "command5",
            };
            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;
            var renderer = new ConsoleRenderer(writer);

            renderer.RenderCommands(commands);

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Exactly(5));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RenderCommandsWithPassedZeroCommandStringsShouldCallConsoleWriteLineNever()
        {
            string[] commands = new string[0];
            var renderer = new ConsoleRenderer();

            renderer.RenderCommands(commands);
        }
    }
}
