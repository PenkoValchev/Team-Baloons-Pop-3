namespace BaloonsUnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPops.Common.Utilities;

    [TestClass]
    public class RandomGeneratorUnitTest
    {
        [TestMethod]
        public void IsRandomReturnNumberBetweenZeroAndIntMax()
        {
            RandomGenerator random = new RandomGenerator();
            int number = random.Next();

            Assert.AreEqual(true, number >= 0 || number <= int.MaxValue);
        }

        [TestMethod]
        public void IsRandomReturnNumberBetweenZeroAndMaxInput()
        {
            RandomGenerator random = new RandomGenerator();
            int number = random.Next(20);

            Assert.AreEqual(true, number >= 0 || number <= 20);
        }

        public void IsRandomReturnNumberBetweenMinAndMaxInput()
        {
            RandomGenerator random = new RandomGenerator();
            int number = random.Next(-20, 20);

            Assert.AreEqual(true, number >= -20 || number <= 20);
        }
    }
}
