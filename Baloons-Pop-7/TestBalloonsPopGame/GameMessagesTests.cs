namespace TestBalloonsPopGame
{
    using Balloons.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class GameMessagesTests
    {
        public string[] cmd = new string[] 
        { 
            "'top' - View the top scores.", 
            "'restart' - Start a new game.",
            "'save' - Save current field state.",
            "'restore' - Restore last saved field state.",
            "'help' - List all game commands.",
            "'exit' - End game.",
        };

        [TestMethod]
        public void CheckIfValidValueIsRetourned()
        {          
            // not sure if it is correct
            Assert.AreNotEqual(GameMessages.CommandsMessages, cmd);
        }
    }
}
