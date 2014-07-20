namespace BalloonsPops.Common.Interfaces
{
    interface IScoreBoard
    {
        void AddPlayer(IPlayer player);

        bool RemovePlayer(IPlayer player);
    }
}