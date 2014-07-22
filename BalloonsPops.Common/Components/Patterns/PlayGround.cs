namespace BalloonsPops.Common.Components.Patterns
{
    using BalloonsPops.Common.Interfaces;

    public abstract class PlayGround
    {
        public abstract IPlayGroundItem[,] Field { get; set; }
    }
}