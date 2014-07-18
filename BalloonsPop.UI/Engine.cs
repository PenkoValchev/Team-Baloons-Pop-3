namespace BalloonsPops.UI
{
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using BalloonsPops.UI;
    using System;

    public class Engine
    {
        static void Main()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            ScoreHandler.InitScoreList();

            var consoleRender = new ConsoleRender(shootableBalloonBoard);

            IGameEngine newGame = new BalloonGameEngine(consoleRender, shootableBalloonBoard);
            newGame.Start();
        }
    }
}