namespace BalloonsPop.Common.Components.Patterns
{
    using BalloonsPop.Common.Interfaces;

    public abstract class PlayGround
    {
        /// <summary>
        /// Abstract property which is 2-dimensional array holding the Playground
        /// </summary>
        public abstract IPlayGroundItem[,] Field { get; set; }
    }
}