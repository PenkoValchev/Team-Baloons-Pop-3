namespace BaloonsUnitTest
{
    using System;
    using BalloonsPop.Common.Components.Patterns;
    using BalloonsPop.Common.Entities;
    using BalloonsPop.Common.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreBoardProxyUnitTest
    {
        [TestMethod]
        public void TestAddingNewPlayer()
        {
            ScoreBoardProxy scoreBoard = new ScoreBoardProxy();

            IPlayer newPlayer = new Player("Pesho", 10);
            scoreBoard.AddPlayer(newPlayer);

            int expected = 1;

            Assert.AreEqual(scoreBoard.ScoreBoardList.Count, expected);
        }

        [TestMethod]
        public void TestAddingNewPlayerAndRemovingTheSomePlayer()
        {
            ScoreBoardProxy scoreBoard = new ScoreBoardProxy();
            scoreBoard.RemovePlayer(scoreBoard.ScoreBoardList[0]);

            IPlayer pesho = new Player("Pesho", 10);
            scoreBoard.AddPlayer(pesho);

            IPlayer ivan = new Player("Ivan", 20);
            scoreBoard.AddPlayer(ivan);

            scoreBoard.RemovePlayer(pesho);

            int expected = 1;

            Assert.AreEqual(scoreBoard.ScoreBoardList.Count, expected);
            Assert.AreEqual(scoreBoard.ScoreBoardList[0], ivan);
        }

        [TestMethod]
        public void AddingSixPlayersToScoreBoard()
        {
            ScoreBoardProxy scoreBoard = new ScoreBoardProxy();

            IPlayer stamat = new Player("Stamat", 40);
            scoreBoard.AddPlayer(stamat);

            IPlayer pesho = new Player("Pesho", 10);
            scoreBoard.AddPlayer(pesho);

            IPlayer ivan = new Player("Ivan", 20);
            scoreBoard.AddPlayer(ivan);

            IPlayer gosho = new Player("Gosho", 30);
            scoreBoard.AddPlayer(gosho);

            IPlayer teodora = new Player("Teodora", 50);
            scoreBoard.AddPlayer(teodora);

            IPlayer maria = new Player("Maria", 60);
            scoreBoard.AddPlayer(maria);

            Assert.AreEqual(scoreBoard.ScoreBoardList[0], ivan);
            Assert.AreEqual(scoreBoard.ScoreBoardList[4], maria);
        }
    }
}