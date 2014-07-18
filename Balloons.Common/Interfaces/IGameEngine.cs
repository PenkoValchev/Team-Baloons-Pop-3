namespace BalloonsPops.Common.Interfaces
{
    using BalloonsPops.Common.Entities;

    public interface IGameEngine
    {
        void ViewScore();

        void Start();

        void NewGame();

        void GameOver();

        void ShowGameBoard();
    }
}