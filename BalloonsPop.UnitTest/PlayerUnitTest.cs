namespace BaloonsUnitTest
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerUnitTest
    {
        [TestMethod]
        public void PlayerIfSetterIsNullOrEmpty()
        {
            string message = "";

            try
            {
                Player player = new Player(null);
            }
            catch (ArgumentNullException ex)
            {
                message = ex.ToString();
            }
            StringAssert.Contains(message, "Name could not be empty or null!");
        }

        [TestMethod]
        public void PlayerIfSetterIsEmpty()
        {
            string message="";

            try
            {
                Player player = new Player(string.Empty);
            }
            catch (ArgumentNullException ex)
            {
                message = ex.ToString();
            }
            StringAssert.Contains(message,"Name could not be empty or null!");
        }

        [TestMethod]
        public void PlayerIfSetterIsWhiteSpace()
        {
            string message = "";

            try
            {
                Player player = new Player(" ");
            }
            catch (ArgumentException ex)
            {
                message = ex.ToString();
            }
            StringAssert.Contains(message, "Name could not be only whitespace!");
        }

        [TestMethod]
        public void PlayerIfLenghtIsLessByTwo()
        {

            try
            {
                Player player = new Player("a");
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.ToString(),"Name could not be less 2 letters!");
            }
           
        }

        [TestMethod]
        public void PlayerIfNameIsSaveCorrect()
        {
            string expected = "Pesho";
            Player player = new Player(expected);
            Assert.AreEqual(expected, player.Name);
        }

        [TestMethod]
        public void PlayerIfScoreLessThanZero()
        {
            try
            {
                Player player = new Player("Pesho", -1);
              
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.ToString(), "Score can't be less than zero.");
            }
        }

        [TestMethod]
      
        public void PlayerIfNameIsNull()
        {
            Player player = new Player();
            string expect = "Unknown";
            Assert.AreEqual(expect, player.Name);
        }

        [TestMethod]

        public void PlayerIfNameIsNullAndScoreIsNotNull()
        {
            Player player = new Player(12);
            string expect = "Unknown";
            Assert.AreEqual(expect, player.Name);
            Assert.AreEqual(12, player.Score);
        }


        [TestMethod]
        public void PlayerIfScoreIsSaveCorrect()
        {
            int expected = 3;
            Player player = new Player("Pesho", expected);
            Assert.AreEqual(expected, player.Score);
        }

        [TestMethod]
        public void PlayerIsGreaterThanAnother()
        {
            int expected = 1;
            Player firstPlayer = new Player("Pesho", 10);
            Player secondPlayer = new Player("Gosho", 6);
            Assert.AreEqual(expected, firstPlayer.CompareTo(secondPlayer));
        }

        [TestMethod]
        public void PlayerIsLessThanAnother()
        {
            int expected = 0;
            IPlayer firstPlayer = new Player("Pesho", 6);
            IPlayer secondPlayer = new Player("Gosho", 6);

            Assert.AreEqual(expected, firstPlayer.CompareTo(secondPlayer));
        }
    }
}