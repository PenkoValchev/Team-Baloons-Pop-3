namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Interfaces;
    using System;

    public class Shootable : Decorator
    {
        private int shootCounts = 0;
        public const int INITIAL_BALLOONS_COUNT = 50;
        private int balloonsCount = INITIAL_BALLOONS_COUNT;

        public Shootable(PlayGround playGround)
            : base(playGround)
        { }

        public int ItemsCount
        {
            get
            {
                return this.balloonsCount;
            }
            set
            {
                this.balloonsCount = value;
            }
        }

        public int Width
        {
            get
            {
                return this.PlayGround.Field.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return this.PlayGround.Field.GetLength(0);
            }
        }

        public int ShootCounter
        {
            get
            {
                return shootCounts;
            }
        }

        public void Shoot(IBalloon balloon)
        {
            BalloonTypes currentBallonType = ((IBalloon)this.PlayGround.Field[balloon.Row, balloon.Column]).Type;

            if (currentBallonType == BalloonTypes.Deflated)
            {
                throw new InvalidOperationException("Wrong move: Cannot pop missing balloon!");
            }

            var directionsValues = Enum.GetValues(typeof(Directions));

            foreach (var direction in directionsValues)
            {
                IBalloon baseBalloon = ((Balloon)balloon).Clone();
                while (true)
                {
                    if (!AllocatePopingByDirection(baseBalloon, (Directions)direction))
                    {
                        break;
                    }
                }
            }

            SetBalloonToGameBoard(balloon, BalloonTypes.Deflated);
            this.ItemsCount--;

            shootCounts++;
            LandFlyingBaloons();
        }

        private bool IsPopNeighbourSuccessful(BalloonTypes balloonType, IBalloon neighbourBalloon)
        {
            if (balloonType == ((IBalloon)this.PlayGround.Field[neighbourBalloon.Row, neighbourBalloon.Column]).Type)
            {
                SetBalloonToGameBoard(neighbourBalloon, BalloonTypes.Deflated);
                this.ItemsCount--;

                return true;
            }

            return false;
        }

        private bool TryPopNeighbours(bool isMoveUpDown, int value, IBalloon balloon)
        {

            IBalloon neighbourBalloon = new Balloon(balloon.Row, balloon.Column);
            try
            {
                neighbourBalloon.ChangePositionByDirection(isMoveUpDown, value);

                if (IsPopNeighbourSuccessful(balloon.Type, neighbourBalloon))
                {
                    balloon.ChangePositionByDirection(isMoveUpDown, value);
                    return true;
                }
            }
            catch (ArgumentException)
            { }

            return false;
        }

        private bool AllocatePopingByDirection(IBalloon balloon, Directions direction)
        {
            if (direction == Directions.Up)
            {
                return TryPopNeighbours(true, -1, balloon);
            }

            if (direction == Directions.Down)
            {
                return TryPopNeighbours(true, 1, balloon);
            }

            if (direction == Directions.Left)
            {
                return TryPopNeighbours(false, -1, balloon);
            }
            if (direction == Directions.Right)
            {
                return TryPopNeighbours(false, 1, balloon);
            }

            return false;
        }

        private void SwapBalloons(IBalloon firstBalloon, IBalloon secondBalloon)
        {
            firstBalloon.Type = secondBalloon.Type;
            secondBalloon.Type = BalloonTypes.Deflated;

            SetBalloonToGameBoard(firstBalloon);
            SetBalloonToGameBoard(secondBalloon);
        }

        private void LandFlyingBaloons()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    if (((IBalloon)this.PlayGround.Field[row, col]).Type == BalloonTypes.Deflated)
                    {
                        for (int swapingRow = row; swapingRow > 0; swapingRow--)
                        {
                            IBalloon upperOfDeflatedBalloon = (IBalloon)this.PlayGround.Field[swapingRow - 1, col];

                            if (upperOfDeflatedBalloon.Type != BalloonTypes.Deflated)
                            {
                                IBalloon deflatedBalloon = (IBalloon)this.PlayGround.Field[swapingRow, col];
                                SwapBalloons(deflatedBalloon, upperOfDeflatedBalloon);
                            }
                        }
                    }
                }
            }
        }

        private void SetBalloonToGameBoard(IBalloon balloon, BalloonTypes balloonType)
        {
            balloon.Type = balloonType;
            SetBalloonToGameBoard(balloon);
        }

        private void SetBalloonToGameBoard(IBalloon balloon)
        {
            this.Field[balloon.Row, balloon.Column] = balloon;
        }
    }
}