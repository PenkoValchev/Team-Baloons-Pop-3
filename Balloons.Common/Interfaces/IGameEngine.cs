namespace BalloonsPops.Common.Interfaces
{
    using BalloonsPops.Common.Entities;

    public interface IGameEngine
    {
        void ViewScore();

        void Start();

        void Quit();

        void NewGame();

        void GameOver();

        void ShowGameBoard();

        PlayGround GameBoard { get; }
    }
}