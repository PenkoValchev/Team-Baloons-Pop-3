using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPops.Common.Entities;
using BalloonsPops.Common.Actions;
using BalloonsPops.Common.Interfaces;

namespace BaloonsUnitTest
{
    [TestClass]
    public class Playertest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name could not be empty or null!")]
        public void PlayerIfSetterIsNullOrEmpty()
        {
            Player player = new Player(null); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name could not be empty or null!")]
        public void PlayerIfSetterIsEmpty()
        {
            Player player = new Player("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Name could not be only whitespace!")]
        public void PlayerIfSetterIsWhiteSpace()
        {
            Player player = new Player(" ");
        }

         [TestMethod]
         [ExpectedException(typeof(ArgumentException), "Name could not be less 2 letters!")]
        public void PlayerIfLenghtIsLessByTwo()
        {
            Player player = new Player("1");
        }

         [TestMethod]
         public void PlayerIfNameIsSaveCorrect()
         {
             string expected = "Pesho";
             Player player = new Player(expected);
             Assert.AreEqual(expected, player.Name);
         }

         [TestMethod]
         [ExpectedException(typeof(ArgumentException), "Score can't be less than zero.")]
         public void PlayerIfScoreLessThanZero() 
         {
             Player player = new Player("Pesho",-1);
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
             bool expected = true;
             Player firstPlayer = new Player("Pesho",10);
             Player secondPlayer = new Player("Gosho",6);
             Assert.AreEqual(expected, firstPlayer > secondPlayer);
         }


         [TestMethod]
         public void PlayerIsLessThanAnother()
         {
             bool expected = true;
             Player firstPlayer = new Player("Pesho", 1);
             Player secondPlayer = new Player("Gosho", 6);
             Assert.AreEqual(expected, firstPlayer < secondPlayer);
         }
        
        
    }
}
