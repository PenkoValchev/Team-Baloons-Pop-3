namespace BalloonsPop.ConsoleUI
{
    using System;
    using BalloonsPop.Common.Components;
    using BalloonsPop.Common.Components.Patterns;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Entities;

    internal static class Engine
    {
        internal static IGameEngine GenerateGameEngine()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            var consoleRender = new ConsoleRender(shootableBalloonBoard);
            var consoleReader = new ConsoleReader();
            var player = new Player();

            IGameEngine newGame = new BalloonGameEngine(consoleRender, consoleReader, shootableBalloonBoard, player);

            return newGame;
        }

        internal static void StartGame()
        {
            IGameEngine gameEngine = GenerateGameEngine();
            ICommandInvoker invoker = new CommandInvoker(gameEngine);

            gameEngine.Start(invoker);
        }

        internal static void Main()
        {
            StartGame();
        }
    }
}