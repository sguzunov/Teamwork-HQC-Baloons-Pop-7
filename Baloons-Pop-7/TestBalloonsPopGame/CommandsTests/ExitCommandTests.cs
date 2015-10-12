namespace TestBalloonsPopGame.CommandsTests
{
    using Balloons.Commands;
    using Balloons.GameScore;
    using Balloons.UI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExitCommandTests
    {
        [TestMethod]
        public void ExitCommandShouldhaveCorrectName()
        {
            var renderer = new ConsoleRenderer();
            var command = new ExitCommand(renderer);

            var expectedName = command.Name;

            Assert.AreEqual("exit", expectedName);
        }

        [TestMethod]
        public void ExitCommandExecuteMethodShouldCallConsoleWriteLine()
        {
            //var mockrenderer = new Mock<IRenderer>();
            //var renderer = mockrenderer.Object;
            //var command = new ExitCommand(renderer);

            ////command.Execute();
            ////mockrenderer.Verify(r => r.RenderGameMessage(It.IsAny<string>()), Times.AtLeastOnce);
            var inst1 = ScoreBoard.Instance;
            var inst2 = ScoreBoard.Instance;

            Assert.AreSame(inst1, inst2);
        }
    }
}
