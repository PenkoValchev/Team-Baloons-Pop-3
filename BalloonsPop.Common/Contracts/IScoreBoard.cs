namespace BalloonsPop.Common.Contracts
{
    public interface IScoreBoard
    {
        void AddPlayer(IPlayer player);

        bool RemovePlayer(IPlayer player);
    }
}