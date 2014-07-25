namespace BaloonsUnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using BalloonsPops.Common.Utilities;
    using BalloonsPops.Common.Utilities.Extensions;
    using BalloonsPops.ConsoleUI;

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
        public void TestShooting()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            balloonBoard.RePopulate();
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            IGameReader reader = new ConsoleReader();
            IGameRender render = new ConsoleRender(shootableBalloonBoard);
            IPlayer pesho = new Player("Pesho");

            BalloonGameEngine gameEngine = new BalloonGameEngine(render, reader, shootableBalloonBoard, pesho);

            shootableBalloonBoard.Action(gameEngine, CommandTypes.Shoot, "0 0");

            Assert.AreEqual(((IBalloon)shootableBalloonBoard.Field[0, 0]).Type, BalloonTypes.Deflated);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Wrong move:Cannot pop missing balloon!")]
        public void TestShootingDeflatedBalloon()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            balloonBoard.RePopulate();
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            IGameReader reader = new ConsoleReader();
            IGameRender render = new ConsoleRender(shootableBalloonBoard);
            IPlayer pesho = new Player("Pesho");

            BalloonGameEngine gameEngine = new BalloonGameEngine(render, reader, shootableBalloonBoard, pesho);

            shootableBalloonBoard.Action(gameEngine, CommandTypes.Shoot, "0 0");
            shootableBalloonBoard.Action(gameEngine, CommandTypes.Shoot, "0 0");
        }

        [TestMethod]
        public void TestSwappingDeflatedBalloons()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            balloonBoard.RePopulate();
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            IGameReader reader = new ConsoleReader();
            IGameRender render = new ConsoleRender(shootableBalloonBoard);
            IPlayer pesho = new Player("Pesho");

            BalloonGameEngine gameEngine = new BalloonGameEngine(render, reader, shootableBalloonBoard, pesho);

            shootableBalloonBoard.Action(gameEngine, CommandTypes.Shoot, "4 0");

            Assert.AreEqual(((IBalloon)shootableBalloonBoard.Field[0, 0]).Type, BalloonTypes.Deflated);
        }

        [TestMethod]
        public void TestRestartShootable()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            balloonBoard.RePopulate();
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            IGameReader reader = new ConsoleReader();
            IGameRender render = new ConsoleRender(shootableBalloonBoard);
            IPlayer pesho = new Player("Pesho");

            BalloonGameEngine gameEngine = new BalloonGameEngine(render, reader, shootableBalloonBoard, pesho);

            BalloonTypes type1 = ((IBalloon)shootableBalloonBoard.Field[0, 0]).Type;
            BalloonTypes type2 = ((IBalloon)shootableBalloonBoard.Field[0, 1]).Type;

            shootableBalloonBoard.Action(gameEngine, CommandTypes.Restart);

            BalloonTypes newType1 = ((IBalloon)shootableBalloonBoard.Field[0, 0]).Type;
            BalloonTypes newType2 = ((IBalloon)shootableBalloonBoard.Field[0, 1]).Type;

            Assert.AreNotEqual(type1, newType1);
            Assert.AreNotEqual(type2, newType2);
        }
    }
}