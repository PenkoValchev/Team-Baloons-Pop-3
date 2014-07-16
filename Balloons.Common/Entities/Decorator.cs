namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Interfaces;

    public abstract class Decorator: PlayGround
    {
        protected internal Decorator(PlayGround playGround)
        {
            this.PlayGround = playGround;
        }

        protected PlayGround PlayGround { get; set; }

        public override IPlayGroundItem[,] Field
        {
            get
            {
                return this.PlayGround.Field;
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}