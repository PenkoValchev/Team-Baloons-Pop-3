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

        /// <summary>
        /// Returns game result
        /// </summary>
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
        
        /// <summary>
        /// Returns true if game is still playing and false if it's game over
        /// </summary>
        public bool IsGameOn { get; set; }

        /// <summary>
        /// This method calls a view score method of IGameRender
        /// </summary>
        public void ViewScore()
        {
            this.gameRender.ViewScore();
        }

        /// <summary>
        /// This method calls a start method of IGameRender
        /// </summary>
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

        /// <summary>
        /// This method calls a quit method of IGameRender
        /// </summary>
        public void Quit()
        {
            this.gameRender.Quit();
        }

        /// <summary>
        /// This method calls a visualize gameboard method of IGameRender
        /// </summary>
        public void ShowGameBoard()
        {
            this.gameRender.ShowGameBoard();
        }

        /// <summary>
        /// This method calls a new game method of IGameRender
        /// </summary>
        public void NewGame()
        {
            this.gameRender.StartNewGame();
        }

        /// <summary>
        /// This method calls a game over method of IGameRender
        /// </summary>
        public void GameOver()
        {
            this.gameRender.GameOver(this.player);
        }
    }
}