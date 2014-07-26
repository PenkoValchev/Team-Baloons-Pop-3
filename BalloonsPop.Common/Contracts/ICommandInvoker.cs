namespace BalloonsPop.Common.Contracts
{
    public interface ICommandInvoker
    {
        void Execute<T>(T input);
    }
}
