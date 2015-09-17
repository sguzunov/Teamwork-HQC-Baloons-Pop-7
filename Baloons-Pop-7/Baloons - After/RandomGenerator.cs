namespace BalloonsPops
{
    using System;
    using System.Linq;
    public static class RamdomGenerator
    {
        static Random rnd = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string result = null;
            result = legalChars[rnd.Next(0, legalChars.Length)].ToString();
            return result;
        }
    }
}
