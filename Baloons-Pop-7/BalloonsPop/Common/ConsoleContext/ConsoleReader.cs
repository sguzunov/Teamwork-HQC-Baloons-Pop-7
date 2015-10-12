namespace Balloons.Common.ConsoleContext
{
    using System;

    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
