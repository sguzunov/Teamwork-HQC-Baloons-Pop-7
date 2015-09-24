namespace Balloons.Commands
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class StatisticsCommand
    {
        
        internal static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();

        internal static void Show()
        {
            var position = GameConstants.FIRST_STATISTIC_POSITION;

            Console.WriteLine("Scoreboard:");
            foreach (KeyValuePair<int, string> statistic in statistics)
            {
                if (position == GameConstants.LAST_STATISTIC_POSITION )
                {
                    break;
                }
                else
                {
                    position++;
                    Console.WriteLine("{0}. {1} --> {2} moves", position, statistic.Value, statistic.Key);
                }
            }
        }
    }
}

