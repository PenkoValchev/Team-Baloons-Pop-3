namespace BalloonsPops.Common.Utilities
{
    using System;
    using BalloonsPops.Common.Interfaces;

    public class RandomGenerator : IRandomGenerator
    {
        private static readonly Random random = new Random();

        public int Next()
        {
            return this.Next(0, int.MaxValue - 1);
        }

        public int Next(int maxValue)
        {
            return this.Next(0, maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }
    }
}