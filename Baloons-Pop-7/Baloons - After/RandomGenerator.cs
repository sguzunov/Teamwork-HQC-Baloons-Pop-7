namespace Balloons
{
    using System;

    public class RandomGenerator
    {
        private static Random instance;

        private RandomGenerator()
        {
        }

        public static Random Instance
        {
            get
            {
                if (instance == null)
                {
                    return new Random();
                }

                return instance;
            }
        }
    }
}
