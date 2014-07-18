namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Interfaces;
    using System;

    public class BalloonGameEngine : IGameEngine
    {
        private IGameRender gameRender;
        private PlayGround playground;
        private Shootable shootableBoard;

        public BalloonGameEngine(IGameRender render, PlayGround playground)
        {
            this.gameRender = render;
            this.playground = playground;
        }

        public void ViewScore()
        {
            this.gameRender.ViewScore();
        }

        public void Start()
        {
            this.NewGame();
            this.ShowGameBoard();

            Shootable shootableBalloonBoard = playground as Shootable;

            while (true)
            {
                if (shootableBalloonBoard.ItemsCount > 0)
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
                                case CommandTypes.TOP:
                                    this.ViewScore();
                                    break;
                                case CommandTypes.RESTART:
                                    this.NewGame();
                                    this.ShowGameBoard();
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
                    this.shootableBoard = shootableBalloonBoard;
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