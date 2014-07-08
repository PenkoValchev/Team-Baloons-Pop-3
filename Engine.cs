﻿namespace BalloonsPops
{
    using BalloonsPops.Actions;
    using BalloonsPops.Entities;
    using System;

    public class Engine
    {
        private const string TOP = "top";
        private const string RESTART = "restart";
        private const string EXIT = "exit";
        private const string ENTER_PLAYER_NAME = "Please enter your name for the top scoreboard: ";

        static void Main()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.GenerateNewGame();
            gameBoard.PrintGameBoard();
            TopScore topScore = new TopScore();

            topScore.OpenTopScoreList();

            bool isCoordinates;
            Coordinates coordinates = new Coordinates();
            Command command = new Command();

            while (gameBoard.RemainingBaloons > 0)
            {
                if (gameBoard.ReadInput(out isCoordinates, ref coordinates, ref command))
                {
                    if (isCoordinates)
                    {
                        gameBoard.Shoot(coordinates);
                        gameBoard.PrintGameBoard();
                    }
                    else
                    {
                        switch (command.Value)
                        {
                            case TOP:
                                topScore.PrintScoreList();
                                break;
                            case RESTART:
                                gameBoard.GenerateNewGame();
                                gameBoard.PrintGameBoard();
                                break;
                            case EXIT:
                                return;
                            default:
                                throw new ArgumentException("Command value is not correct");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input!");
                }
            }


            //TODO Checking is top score should not depend of creating instance of player.
            //This takes useless memory. Need to be changed.

            Console.WriteLine(ENTER_PLAYER_NAME);
            string playerName = Console.ReadLine();
            int playerScore = gameBoard.ShootCounter;

            Player player = new Player(playerName, playerScore);
            
            if (topScore.IsTopScore(player))
            {
                topScore.AddToTopScoreList(player);
            }

            topScore.SaveTopScoreList();
        }
    }
}