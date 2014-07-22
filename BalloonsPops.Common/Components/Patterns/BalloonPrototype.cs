namespace BalloonsPops.Common.Components.Patterns
{
    using BalloonsPops.Common.Entities;

    internal abstract class BalloonPrototype
    {
        public abstract Balloon Clone();
    }
}