namespace Balloons.Commands
{
    using System;
    using System.Threading;

    using Balloons.Common;

    public class ExitCommand
    {
        internal static void Exit()
        {
            Console.WriteLine(GameMessages.END_GAME_MESSAGE);
            Thread.Sleep(1000);
            //Console.WriteLine(counter.ToString());
            //Console.WriteLine(filledCells.ToString());
            Environment.Exit(0);
        }
    }
}
