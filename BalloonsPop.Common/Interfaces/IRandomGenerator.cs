namespace BalloonsPop.Common.Interfaces
{
    public interface IRandomGenerator
    {
        int Next();

        int Next(int maxValue);

        int Next(int minValue, int maxValue);
    }
}
