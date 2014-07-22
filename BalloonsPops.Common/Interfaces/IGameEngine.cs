namespace BalloonsPops.Common.Interfaces
{
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Entities;

    public interface IGameEngine
    {
        PlayGround GameBoard { get; }

        int GameResult { get; set; }

        ICommandInvoker Invoker { get; set; }

        bool IsGameOn { get; set; }

        void ViewScore();

        void Start();

        void Quit();

        void NewGame();

        void GameOver();

        void ShowGameBoard();
    }
}