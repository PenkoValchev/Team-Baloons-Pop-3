namespace BaloonsUnitTest
{
    using BalloonsPop.Common.Components.Patterns;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Entities;
    using BalloonsPop.ConsoleUI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    [TestClass]
    public class ScoreHandlerTest
    {
        [TestInitialize]

        public void InitializeTest()
        {
            StreamWriter standardOut =new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [TestMethod]
        public void ScoreHandlerGetScoreBoardTest()
        {
            ScoreBoardProxy scoreBoard = new ScoreBoardProxy();
            IPlayer player = new Player("Pesho", 10000);
            scoreBoard.AddPlayer(player);

            StringAssert.Equals(string.Empty, ScoreHandler.GetScoreBoard());
        }
    }
}
