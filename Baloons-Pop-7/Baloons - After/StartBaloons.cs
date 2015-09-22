namespace Balloons
{
    using System;

    using Balloons.Commands;
    using System.Linq;
    using Balloons.GameField;

    public class StartBaloons
    {
        public static void Main(string[] args)
        {
            StartCommand.Start();
        }
    }
}
