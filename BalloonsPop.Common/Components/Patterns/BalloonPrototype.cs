namespace BalloonsPop.Common.Components.Patterns
{
    using BalloonsPop.Common.Entities;

    internal abstract class BalloonPrototype
    {
        public abstract Balloon Clone();
    }
}