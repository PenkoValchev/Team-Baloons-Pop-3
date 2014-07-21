namespace BalloonsPops.Common.Components
{
    using System;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Interfaces;

    public class BalloonGameEngine : IGameEngine
    {
        private readonly IGameRender gameRender;
        private readonly Shootable shootableBoard;
        private readonly IGameReader gameReader;

        public BalloonGameEngine(IGameRender render, IGameReader reader, PlayGround playground)
        {
            this.gameRender = render;
            this.gameReader = reader;
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
                if (this.IsGameOn())
                {
                    string input = this.gameReader.Read<string>();

                    try
                    {
                        commandInvoker.Execute(input);
                    }
                    catch (Exception ex)
                    {
                        this.gameRender.ErrorHandler(ex);
                    }
                }
                else
                {
                    this.GameOver();
                    break;
                }
            }
        }

        public void Quit()
        {
            this.gameRender.Quit();
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