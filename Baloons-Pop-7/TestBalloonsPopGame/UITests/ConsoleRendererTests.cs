﻿using System;
using System.Collections.Generic;
using Balloons.GamePlayer;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RenderGameTopPlayersWhenPassedNullShouldthrowException()
        {
            var renderer = new ConsoleRenderer();

            renderer.RenderGameTopPlayers(null);
        }

        [TestMethod]
        public void RenderGameTopPlayersWhenPassedOnePlayerShouldInvokeConsoleWriteLineOnce()
        {
            var player = new Player();
            player.Name = "Player";
            player.Moves = 20;
            var players = new List<IPlayer>()
            {
                player
            };

            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;
            var renderer = new ConsoleRenderer(writer);

            renderer.RenderGameTopPlayers(players);

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Exactly(1));
        }

        [TestMethod]
        public void RenderGameTopPlayersWhenPassedThreePlayerShouldInvokeConsoleWriteLineMoreThanOnce()
        {
            var player = new Player();
            player.Name = "Player";
            player.Moves = 20;
            var player1 = new Player();
            player.Name = "Player1";
            player.Moves = 10;
            var player2 = new Player();
            player.Name = "Player2";
            player.Moves = 30;

            var players = new List<IPlayer>()
            {
                player,
                player1,
                player2
            };

            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;
            var renderer = new ConsoleRenderer(writer);

            renderer.RenderGameTopPlayers(players);

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void RenderGameTopPlayersWhenPassedZeroPlayerShouldInvokeConsoleWriteLineNever()
        {

            var players = new List<IPlayer>();

            var mockConsole = new Mock<IConsoleWriter>();
            var writer = mockConsole.Object;
            var renderer = new ConsoleRenderer(writer);

            renderer.RenderGameTopPlayers(players);

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RenderGameFieldWhenPassedNullShouldThrowException()
        {
            var renderer = new ConsoleRenderer();

            renderer.RenderGameField(null);
        }
    }
}
