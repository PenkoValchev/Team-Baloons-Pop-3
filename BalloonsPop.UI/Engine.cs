namespace BalloonsPops.UI
{
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;

    public class Engine
    {
        private const string ENTER_PLAYER_NAME = "Please enter your name for the top scoreboard: ";

        static void Main()
        {
            BalloonBoard balloonBoard = BalloonBoard.Instance;
            Shootable shootableBalloonBoard = new Shootable(balloonBoard);

            ConsolePrint.GenerateNewGame();
            ConsolePrint.PrintGameBoard();

            Score.InitScoreList();

            while (shootableBalloonBoard.ItemsCount > 0)
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
                                ConsolePrint.PrintScoreList();
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
                        IBalloon balloon = Utils.ParseBalloon(input);
                        shootableBalloonBoard.Shoot(balloon);
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

            Console.WriteLine(ENTER_PLAYER_NAME);
            string playerName = Console.ReadLine();
            int playerScore = shootableBalloonBoard.ShootCounter;

            IPlayer player = new Player(playerName, playerScore);

            if (Score.TryAdd(player))
            {
                Score.Save();
            }
            
            ConsolePrint.PrintScoreList();
        }
    }
}