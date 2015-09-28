namespace Balloons
{
    using System;

    using Balloons.Commands;
    using System.Linq;
    using Balloons.GameField;
    using Balloons.UI;
    using Balloons.GamePlayer;
    using Balloons.GameFieldFactories;
    using Balloons.Helpers;
    using Balloons.Common;
    using Balloons.GameScore;

    public class StartBaloons
    {
        public static void Main(string[] args)
        {
            // StartCommand.Start();

            Facade.StartGame();
        }
    }
}
