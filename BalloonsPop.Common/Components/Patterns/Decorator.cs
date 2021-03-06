﻿namespace BalloonsPop.Common.Components.Patterns
{
    using BalloonsPop.Common.Contracts;

    public abstract class Decorator : PlayGround
    {
        /// <summary>
        /// Decorator constructor which holds specific playgraound and can extend his possabilities.
        /// </summary>
        /// <param name="playGround">Instance of playground</param>
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