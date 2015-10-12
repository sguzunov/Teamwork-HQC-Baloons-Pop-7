namespace Balloons
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// This class is responsible for providing the game with random numbers.
    /// </summary>
    public static class RandomProvider
    {
        /// <summary>
        /// Provides an instance of RNGCryptoServiceProvider class.
        /// </summary>
        private static readonly RNGCryptoServiceProvider Provider = new RNGCryptoServiceProvider();

        /// <summary>
        /// Generates random number depending the passed bounds.
        /// </summary>
        /// <param name="minSize">Minimal generated value.</param>
        /// <param name="maxSize">Maximal generated value.</param>
        /// <returns>Randomly generated number in the bounds.</returns>
        public static int GetRandomNumber(int minSize, int maxSize)
        {
            byte[] randomBytes = new byte[4];

            Provider.GetBytes(randomBytes);

            // Conver 4 bytes into a 32-bit integer value
            int seed = BitConverter.ToInt32(randomBytes, 0);

            Random random = new Random(seed);

            int randomValue = 0;
            randomValue = random.Next(minSize, maxSize);

            return randomValue;
        }
    }
}