namespace BalloonsPops.Common.Utilities
{
    using System;
    using BalloonsPops.Common.Interfaces;

    public class RandomGenerator : IRandomGenerator
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// </summary>
        /// <returns>Random number from 0 to int.MaxValue</returns>
        public int Next()
        {
            return this.Next(0, int.MaxValue - 1);
        }

        /// <summary>
        /// </summary>
        /// <param name="maxValue">Maximum value</param>
        /// <returns>Random number from 0 to maxValue</returns>
        public int Next(int maxValue)
        {
            return this.Next(0, maxValue);
        }

        /// <summary>
        /// </summary>
        /// <param name="minValue">Minimum value</param>
        /// <param name="maxValue">Maximum value</param>
        /// <returns>Random number form minimum value to maximum value</returns>
        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }
    }
}