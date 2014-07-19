namespace BalloonsPops.UI
{
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;

    internal class Engine
    {
        public static void StartGame()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            var consoleRender = new ConsoleRender(shootableBalloonBoard);

            IGameEngine newGame = new BalloonGameEngine(consoleRender, shootableBalloonBoard);
            newGame.Start();
        }

        static void Main()
        {
            StartGame();
        }
    }
}