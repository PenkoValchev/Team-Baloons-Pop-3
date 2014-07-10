namespace BalloonsPops.Game
{
    using BalloonsPops.Game.Actions;
    using BalloonsPops.Game.Entities;
    using BalloonsPops.Game.Interfaces;
    using System;

    public class Engine
    {
        private const string ENTER_PLAYER_NAME = "Please enter your name for the top scoreboard: ";

        static void Main()
        {
            GameBoard gameBoard = GameBoard.Instance;
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
                        switch (command.Name)
                        {
                            case Command.TOP:
                                topScore.PrintScoreList();
                                break;
                            case Command.RESTART:
                                gameBoard.GenerateNewGame();
                                gameBoard.PrintGameBoard();
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