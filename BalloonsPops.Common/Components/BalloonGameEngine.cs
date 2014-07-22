namespace BalloonsPops.Common.Components
{
    using System;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Interfaces;

    public class BalloonGameEngine : IGameEngine
    {
        private readonly IGameRender gameRender;
        private readonly PlayGround shootableBoard;
        private readonly IGameReader gameReader;
        private readonly IPlayer player;
        private ICommandInvoker invoker;

        public BalloonGameEngine(IGameRender render, IGameReader reader, PlayGround playground, IPlayer player)
        {
            this.gameRender = render;
            this.gameReader = reader;
            this.shootableBoard = playground;
            this.player = player;
            this.IsGameOn = true;
        }

        public PlayGround GameBoard
        {
            get
            {
                return this.shootableBoard;
            }
        }

        public ICommandInvoker Invoker 
        {
            get
            {
                if (this.invoker == null)
                {
                    throw new ArgumentException("There is no command invoker passed to the Game Engine!");
                }

                return this.invoker;
            }

            set
            {
                this.invoker = value;
            }
        }

        public int GameResult 
        {
            get
            {
                return this.player.Score;
            }

            set
            {
                this.player.Score = value;
            }
        }

        public bool IsGameOn { get; set; }

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
                if (this.IsGameOn)
                {
                    string input = this.gameReader.Read<string>();

                    try
                    {
                        Invoker.Execute(input);
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
            this.gameRender.GameOver(this.player);
        }
    }
}