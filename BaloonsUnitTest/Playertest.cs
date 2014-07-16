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

        
    }
}
