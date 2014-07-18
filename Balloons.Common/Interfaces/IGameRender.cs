namespace BalloonsPops.Common.Interfaces
{
    public interface IGameRender
    {
        void ViewScore();

        void StartNewGame();

        void ShowGameBoard();

        void GameOver<T>(T score);

        T GetUserInput<T>();
    }
}
