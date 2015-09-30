namespace Balloons.Commands
{
    using System;
    using System.Threading;

    using Balloons.Common;

    /// <summary>
    /// Exit Command
    /// </summary>
    public class ExitCommand
    {
        internal static void Exit()
        {
            Console.WriteLine(GameMessages.END_GAME_MESSAGE);
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
