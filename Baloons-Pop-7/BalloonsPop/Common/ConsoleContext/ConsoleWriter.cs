﻿namespace Balloons.Common.ConsoleContext
{
    using System;

    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
