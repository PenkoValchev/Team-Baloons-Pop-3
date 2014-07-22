namespace BalloonsPops.Common.Interfaces
{
    public interface ICommandInvoker
    {
        void Execute<T>(T input);
    }
}
