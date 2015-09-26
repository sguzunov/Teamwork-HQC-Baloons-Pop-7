namespace Balloons
{
    using System;
    using Balloons.Common;

    public static class RandomGenerator
    {
        static Random randomNumber = new Random();

        public static string GetRandomInt()
        {
            string legalChars = GameConstants.LEGAL_CHARS;
            string result = null;
            result = legalChars[randomNumber.Next(0, legalChars.Length)].ToString();
            return result;
        }
    }
}