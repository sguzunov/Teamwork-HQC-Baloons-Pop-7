namespace Balloons
{
    using System;
    using System.Linq;

    using Balloons.Commands;
    using Balloons.FieldFactory;
    using Balloons.UI;
    using Balloons.GamePlayer;
    using Balloons.FieldFactory.Field;
    using Balloons.Common;
    using System.Text;
    using Balloons.Logic;
    using Balloons.GameRules;
    using Balloons.InputHandler;

    public class StartBalloons
    {

        //private static int moves = 0;
        //private static MemoryManager gameMemory = new MemoryManager();
        //private static bool isUndo = false;
        //public static StringBuilder userInput = new StringBuilder();

        public static void Main(string[] args)
        {
           
            Facade.StartGame();
        }

    }
}
