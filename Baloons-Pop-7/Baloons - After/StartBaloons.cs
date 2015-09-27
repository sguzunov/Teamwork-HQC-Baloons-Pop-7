namespace Balloons
{
    using System;

    using Balloons.Commands;
    using System.Linq;
    using Balloons.GameField;
    using Balloons.UI;
    using Balloons.GamePlayer;

    public class StartBaloons
    {
        public static void Main(string[] args)
        {
            StartCommand.Start();
        }
    }
}
