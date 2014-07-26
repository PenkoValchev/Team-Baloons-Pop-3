namespace BalloonsPop.Common.Contracts
{
    using BalloonsPop.Common.Components.Patterns;

    public interface IGameEngine
    {
        PlayGround GameBoard { get; }

        int GameResult { get; set; }

        bool IsGameOn { get; set; }

        void ViewScore();

        void Start(ICommandInvoker invoker);

        void Quit();

        void NewGame();

        void GameOver();

        void ShowGameBoard();
    }
}