namespace BaloonsUnitTest
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UtilsUnitTest
    {
        [TestMethod]
        public void ParseBalloonWithRegularInput()
        {
            IBalloon balloon = Utils.ParseBalloon("2 0");

            Assert.AreEqual(balloon.Row, 2);
            Assert.AreEqual(balloon.Column, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Wrong row coordinates")]
        public void ParseBalloonWithWrongRowInput()
        {
            IBalloon balloon = Utils.ParseBalloon("-2 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Wrong row coordinates")]
        public void ParseBalloonWithWrongRowInputBiggerThanUsual()
        {
            IBalloon balloon = Utils.ParseBalloon("25 0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Wrong column coordinates")]
        public void ParseBalloonWithWrongColumnInputBiggerThanUsual()
        {
            IBalloon balloon = Utils.ParseBalloon("2 25");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Wrong column coordinates")]
        public void ParseBalloonWithWrongColumnInput()
        {
            IBalloon balloon = Utils.ParseBalloon("2 -2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Wrong row coordinates")]
        public void ParseBalloonWithWrongColumnAndRow()
        {
            IBalloon balloon = Utils.ParseBalloon("-2 -2");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid move or command!")]
        public void ParseBalloonWithWrongInput()
        {
            IBalloon balloon = Utils.ParseBalloon("pesho");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid move or command!")]
        public void ParseBalloonWithWrongInputOfThreeCoordinates()
        {
            IBalloon balloon = Utils.ParseBalloon("10 20 30");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid move or command!")]
        public void ParseBalloonWithWrongRowValue()
        {
            IBalloon balloon = Utils.ParseBalloon("pesho 20");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid move or command!")]
        public void ParseBalloonWithWrongColValue()
        {
            IBalloon balloon = Utils.ParseBalloon("2 pesho");
        }

        [TestMethod]
        public void ParseBalloonWithWrongInputOfNull()
        {
            string message = string.Empty;
            try
            {
                IBalloon balloon = Utils.ParseBalloon(null);
            }
            catch (ArgumentException ex)
            {
                message = ex + "The given input should have some value";
            }

            StringAssert.Contains(message, "The given input should have some value");
        }

        [TestMethod]
        public void ParseBalloonWithEmptyInput()
        {
            string message = string.Empty;
            try
            {
                IBalloon balloon = Utils.ParseBalloon(string.Empty);
            }
            catch (ArgumentException ex)
            {
                message = ex + "The given input should have some value";
            }

            StringAssert.Contains(message, "The given input should have some value");
        }

        [TestMethod]
        public void CheckIfRestartIsShootCommand()
        {
            bool isShoot = Utils.IsShootCommand("restart");

            Assert.AreEqual(false, isShoot);
        }

        [TestMethod]
        public void CheckIsShootCommandIfInputIsNull()
        {
            bool isShoot = Utils.IsShootCommand(null);

            Assert.AreEqual(false, isShoot);
        }

        [TestMethod]
        public void CheckIsShootCommandIfInputIsEmptyString()
        {
            bool isShoot = Utils.IsShootCommand(string.Empty);

            Assert.AreEqual(false, isShoot);
        }

        [TestMethod]
        public void CheckIsShootCommandIfInputIsRealShot()
        {
            bool isShoot = Utils.IsShootCommand("2 3");

            Assert.AreEqual(true, isShoot);
        }
    }
}