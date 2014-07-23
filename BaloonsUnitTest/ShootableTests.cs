namespace BaloonsUnitTest
{
    using System;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using BalloonsPops.Common.Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPops.Common.Utilities;
    using BalloonsPops.Common.Utilities.Extensions;

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
            shootableBalloonBoard.ItemsCount = 10;
            Assert.AreEqual(10, shootableBalloonBoard.ItemsCount);

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
            Assert.AreEqual(50, shootableBalloonBoard.ItemsCount);
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

        [TestMethod]
        public void TestShootableShootTest()
        {              
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);
            IBalloon balloon = new Balloon();
            bool actual = shootableBalloonBoard.Shoot(balloon);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),"Wrong move:Cannot pop missing balloon!")]
        public void TestShootableTryShootDeflatedBaloon()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);
            IBalloon balloon = new Balloon();

            balloon.Type = BalloonTypes.Deflated;
                       bool actual = shootableBalloonBoard.Shoot(balloon);
           
        }


       // [TestMethod]
       //// [ExpectedException(typeof(InvalidOperationException), "Wrong move:Cannot pop missing balloon!")]
       // public void TestShootableTryShootDeflatedBaloo1n()
       // {
       //     BalloonBoard balloonBoard = BalloonBoard.Instance;
       //     Shootable shootableBalloonBoard = new Shootable(balloonBoard);
       //     IBalloon balloon = new Balloon();
       //      IBalloon balloon2 = new Balloon();
       //     balloon.Type = BalloonTypes.Deflated;
       //     balloon2.Type = BalloonTypes.Green;
       //     PrivateObject po = new PrivateObject(typeof(Shootable));
       //     po.Invoke("SwapBalloons",balloon),new object {balloon2});
          

       // }
        
    }
}
