namespace Balloons
{
    using System;
    using System.Security.Cryptography;

    public static class RandomProvider
    {
        private static readonly RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

        public static int GetRandomNumber(int minSize, int maxSize)
        {
            byte[] randomBytes = new byte[4];

            provider.GetBytes(randomBytes);

            // Conver 4 bytes into a 32-bit integer value
            int seed = BitConverter.ToInt32(randomBytes, 0);

            Random random = new Random(seed);

            int randomValue = 0;
            randomValue = random.Next(minSize, maxSize);

            return randomValue;
        }
    }
}