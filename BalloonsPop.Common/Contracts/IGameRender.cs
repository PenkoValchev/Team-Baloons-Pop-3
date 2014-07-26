namespace BalloonsPop.Common.Contracts
{
    using System;

    public interface IGameRender
    {
        void ViewScore();

        void StartNewGame();

        void Quit();

        void ShowGameBoard();

        void GameOver<T>(T player);

        void ErrorHandler(Exception exception); 
    }
}
