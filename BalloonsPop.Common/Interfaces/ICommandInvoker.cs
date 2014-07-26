namespace BalloonsPop.Common.Interfaces
{
    public interface ICommandInvoker
    {
        void Execute<T>(T input);
    }
}
