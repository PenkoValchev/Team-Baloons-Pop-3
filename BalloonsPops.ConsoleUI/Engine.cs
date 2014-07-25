﻿namespace BalloonsPops.ConsoleUI
{
    using System;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;

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