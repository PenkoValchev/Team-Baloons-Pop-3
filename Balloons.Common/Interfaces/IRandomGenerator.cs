namespace BalloonsPops.Common.Interfaces
{
    interface IRandomGenerator
    {
        int Next();

        int Next(int maxValue);

        int Next(int minValue, int maxValue);
    }
}
