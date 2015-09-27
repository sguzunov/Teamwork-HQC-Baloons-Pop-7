namespace Balloons
{
    using System;

    using Balloons.Commands;
    using System.Linq;
    using Balloons.GameField;
    using Balloons.UI;
    using Balloons.GamePlayer;
    using Balloons.GameFieldFactories;

    public class StartBaloons
    {
        public static void Main(string[] args)
        {
            StartCommand.Start();

            //var fac = new GameFieldFactory();
            //var fld = fac.CreateGameField(Common.GameType.Hard);
            //fld.Fill();
            //var renderer = new ConsoleRenderer();
            //renderer.RenderGameField(fld);
        }
    }
}
