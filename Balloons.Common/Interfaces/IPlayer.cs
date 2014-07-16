namespace BalloonsPops.Common.Interfaces
{
    public interface IPlayer
    {
        string Name { get;}

        int Score { get; set; }

        bool ScoreCompare(IPlayer player);
    }
}