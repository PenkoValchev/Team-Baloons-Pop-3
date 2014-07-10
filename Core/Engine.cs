namespace BalloonsPops.Core
{
    using BalloonsPops.Core.Actions;
    using BalloonsPops.Core.Entities;
    using BalloonsPops.Core.Interfaces;
    using BalloonsPops.UI;
    using System;

    public class Engine
    {
        private const string ENTER_PLAYER_NAME = "Please enter your name for the top scoreboard: ";

        static void Main()
        {
            GameBoard gameBoard = GameBoard.Instance;
            ConsolePrint.GenerateNewGame();
            ConsolePrint.PrintGameBoard();
            TopScore topScore = new TopScore();

            topScore.OpenTopScoreList();

            bool isCoordinates;
            Balloon balloon = new Balloon();
            Command command = new Command();

            while (gameBoard.BalloonsCount > 0)
            {
                if (gameBoard.ReadInput(out isCoordinates, ref balloon, ref command))
                {
                    if (isCoordinates)
                    {
                        gameBoard.Shoot(balloon);
                        ConsolePrint.PrintGameBoard();
                    }
                    else
                    {
                        switch (command.Name)
                        {
                            case Command.TOP:
                                topScore.PrintScoreList();
                                break;
                            case Command.RESTART:
                                ConsolePrint.GenerateNewGame();
                                ConsolePrint.PrintGameBoard();
                                break;
                            case Command.EXIT:
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

            IPlayer player = new Player(playerName, playerScore);
            
            if (topScore.IsTopScore(player))
            {
                topScore.AddToTopScoreList(player);
            }

            topScore.SaveTopScoreList();
        }
    }
}