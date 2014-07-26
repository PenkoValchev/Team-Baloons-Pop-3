namespace BalloonsPop.Common.Contracts
{
    public interface IRandomGenerator
    {
        int Next();

        int Next(int maxValue);

        int Next(int minValue, int maxValue);
    }
}
