namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Interfaces;

    public abstract class Decorator : PlayGround
    {
        protected internal Decorator(PlayGround playGround)
        {
            this.PlayGround = playGround;
        }

        public override IPlayGroundItem[,] Field
        {
            get
            {
                return this.PlayGround.Field;
            }

            set
            {
                this.PlayGround.Field = value;
            }
        }

        protected PlayGround PlayGround { get; set; }
    }
}