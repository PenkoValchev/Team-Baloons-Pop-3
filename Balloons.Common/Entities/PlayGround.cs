namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Interfaces;

    public abstract class PlayGround
    {
        public abstract IPlayGroundItem[,] Field { get; set; }
    }
}