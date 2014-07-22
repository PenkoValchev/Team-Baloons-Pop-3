namespace BalloonsPops.ConsoleUI
{
    using System;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;

    internal class Engine
    {
        public static void StartGame()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            var consoleRender = new ConsoleRender(shootableBalloonBoard);
            var consoleReader = new ConsoleReader();
            var player = new Player();

            IGameEngine newGame = new BalloonGameEngine(consoleRender, consoleReader, shootableBalloonBoard, player);
            newGame.Start();
        }

        internal static void Main()
        {
            StartGame();
        }
    }
}