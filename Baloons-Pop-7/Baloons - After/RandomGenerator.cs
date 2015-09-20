namespace Baloons
{
    using System;

    public static class RandomGenerator
    {
        static Random randomNumber = new Random();

        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string result = null;
            result = legalChars[randomNumber.Next(0, legalChars.Length)].ToString();
            return result;
        }
    }
}