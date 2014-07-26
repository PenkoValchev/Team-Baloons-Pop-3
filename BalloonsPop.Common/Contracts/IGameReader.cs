namespace BalloonsPop.Common.Contracts
{
    public interface IGameReader
    {
        T Read<T>();
    }
}