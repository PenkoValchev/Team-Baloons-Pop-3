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

        public PlayGround GameBoard
        {
            get
            {
                return this.shootableBoard;
            }
        }

        public void ViewScore()
        {
            this.gameRender.ViewScore();
        }

        public void Start()
        {
            this.NewGame();
            this.ShowGameBoard();

            var commandInvoker = new CommandInvoker(this);

            while (true)
            {
                if (IsGameOn())
                {
                    string input = this.gameRender.GetUserInput<string>();

                    try
                    {
                        commandInvoker.Execute(input);
                    }
                    catch (ArgumentException ex)
                    {
                        //GameRender Exception handling
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidOperationException ioEx)
                    {
                        Console.WriteLine(ioEx.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
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

        private bool IsGameOn()
        {
            return this.shootableBoard.ItemsCount > 0;
        }
    }
}