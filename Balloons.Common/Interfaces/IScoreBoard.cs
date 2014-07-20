namespace BalloonsPops.Common.Interfaces
{
    public interface IScoreBoard
    {
        void AddPlayer(IPlayer player);

        bool RemovePlayer(IPlayer player);
    }
}