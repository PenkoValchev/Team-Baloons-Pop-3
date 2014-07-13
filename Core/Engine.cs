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
        public static Random random = new Random();

        static void Main()
        {
            GameBoard gameBoard = GameBoard.Instance;
            ConsolePrint.GenerateNewGame();
            ConsolePrint.PrintGameBoard();
            TopScore topScore = new TopScore();

            topScore.OpenTopScoreList();

            while (gameBoard.BalloonsCount > 0)
            {
                var input = ConsolePrint.ReadInput();
                var isCommand = Command.IsValidType(input);

                try
                {
                    if (isCommand)
                    {
                        CommandTypes currentType;
                        Enum.TryParse(input, true, out currentType);

                        switch (currentType)
                        {
                            case CommandTypes.TOP:
                                topScore.PrintScoreList();
                                break;
                            case CommandTypes.RESTART:
                                ConsolePrint.GenerateNewGame();
                                ConsolePrint.PrintGameBoard();
                                break;
                            case CommandTypes.EXIT:
                                return;
                            default:
                                throw new ArgumentException("Command value is not correct");
                        }
                    }
                    else
                    {
                        Balloon balloon = Balloon.Parse(input);
                        gameBoard.Shoot(balloon);
                        ConsolePrint.PrintGameBoard();
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ioEx)
                {
                    Console.WriteLine(ioEx.Message);
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