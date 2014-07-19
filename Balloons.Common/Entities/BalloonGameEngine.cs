namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Interfaces;
    using System;

    public class BalloonGameEngine : IGameEngine
    {
        private readonly IGameRender gameRender;
        private readonly Shootable shootableBoard;

        public BalloonGameEngine(IGameRender render, PlayGround playground)
        {
            this.gameRender = render;
            this.shootableBoard = playground as Shootable;
        }

        public void ViewScore()
        {
            this.gameRender.ViewScore();
        }

        public void Start()
        {
            this.NewGame();
            this.ShowGameBoard();

            while (true)
            {
                if (this.shootableBoard.ItemsCount > 0)
                {
                    string input = this.gameRender.GetUserInput<string>();
                    var isCommand = Command.IsValidType(input);

                    try
                    {
                        if (isCommand)
                        {
                            CommandTypes currentType;
                            Enum.TryParse(input, true, out currentType);

                            switch (currentType)
                            {
                                case CommandTypes.Top:
                                    this.ViewScore();
                                    break;
                                case CommandTypes.Restart:
                                    this.NewGame();
                                    this.ShowGameBoard();
                                    break;
                                case CommandTypes.Exit:
                                    return;
                                default:
                                    throw new ArgumentException("Command value is not correct");
                            }
                        }
                        else
                        {
                            IBalloon balloon = Utils.ParseBalloon(input);
                            this.shootableBoard.Shoot(balloon);
                            this.ShowGameBoard();
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
                else
                {
                    this.GameOver();
                    break;
                }
            }
        }

        public void ShowGameBoard()
        {
            this.gameRender.ShowGameBoard();
        }

        public void NewGame()
        {
            this.gameRender.StartNewGame();
        }

        public void GameOver()
        {
            int playerScore = this.shootableBoard.ShootCounter;
            this.gameRender.GameOver(playerScore);
        }
    }
}