using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPop.Common.Components.Patterns;
using BalloonsPop.Common.Contracts;
using BalloonsPop.Common.Entities;
using BalloonsPop.ConsoleUI;
using System.Text;
using System.IO;

namespace BaloonsUnitTest
{


    [TestClass]
    public class ScoreHandlerTeest
    {

        [TestInitialize]

        public void InitializeTest()
        {

            StreamWriter standardOut =

                new StreamWriter(Console.OpenStandardOutput());

            standardOut.AutoFlush = true;

            Console.SetOut(standardOut);

        }


        [TestMethod]
        public void ScoreHandlerGetScoreBoardTest()
        {
            ScoreBoardProxy scoreBoard = new ScoreBoardProxy();
            IPlayer player = new Player("Pesho", 10000);
            scoreBoard.AddPlayer(player);

            StringAssert.Equals("", ScoreHandler.GetScoreBoard());

        }

    }
}
