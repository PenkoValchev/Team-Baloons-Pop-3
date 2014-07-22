namespace BalloonsPops.Common.Interfaces
{
    using System;

    public interface IGameRender
    {
        void ViewScore();

        void StartNewGame();

        void Quit();

        void ShowGameBoard();

        void GameOver<T>(T score);

        void ErrorHandler(Exception exception); 
    }
}
