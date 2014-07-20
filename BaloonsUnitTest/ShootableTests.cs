namespace BaloonsUnitTest
{
    using System;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ShootableTests
    {
        [TestMethod]
        public void ShootableItemsFoundSetGetTest()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);
            IBalloon balloon = new Balloon();
            Assert.AreEqual(50, shootableBalloonBoard.ItemsCount);
            try
            {
                shootableBalloonBoard.ItemsCount = -1;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.ToString(), "Count", "Error");
            }

            try
            {
                shootableBalloonBoard.ItemsCount = 1111;
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.ToString(), "Count", "Error");
            }
        }

        [TestMethod]
        public void ShootableShootCounterGetSetTest()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);
            IBalloon balloon = new Balloon();
            Assert.AreEqual(0, shootableBalloonBoard.ShootCounter);
        }

        [TestMethod]
        public void ShootableGetHeightTest()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);
            IBalloon balloon = new Balloon();
            Assert.AreEqual(balloonBoard.Field.GetLength(0), shootableBalloonBoard.Height);
        }

        [TestMethod]
        public void ShootableGetWidthTest()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);
            IBalloon balloon = new Balloon();
            Assert.AreEqual(balloonBoard.Field.GetLength(1), shootableBalloonBoard.Width);
        }
    }
}
