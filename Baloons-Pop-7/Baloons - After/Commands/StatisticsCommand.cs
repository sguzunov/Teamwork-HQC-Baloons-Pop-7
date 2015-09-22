namespace Balloons.Commands
{
    using System;
    using System.Collections.Generic;

    public class StatisticsCommand
    {
        const int MAX_POSITION = 4;
        internal static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();

        internal static void Show()
        {
            int position = 0;

            Console.WriteLine("Scoreboard:");
            foreach (KeyValuePair<int, string> statistic in statistics)
            {
                if (position == MAX_POSITION)
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

