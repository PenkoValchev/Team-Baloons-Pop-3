﻿namespace BalloonsPops.Common.Components.Patterns
{
    using System;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using BalloonsPops.Common.Utilities;

    public class Shootable : Decorator
    {
        public const int INITIAL_BALLOONS_COUNT = 50;

        private int shootCounts = 0;
        private int balloonsCount = INITIAL_BALLOONS_COUNT;

        public Shootable(PlayGround playGround)
            : base(playGround)
        {
        }

        public int ItemsCount
        {
            get
            {
                return this.balloonsCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Count cant be less than 0");
                }

                if (value > 1000)
                {
                    throw new ArgumentOutOfRangeException("Count cant be greater than 1000");
                }

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
                return this.shootCounts;
            }

            private set
            {
                this.shootCounts = value;
            }
        }

        public void Shoot(IBalloon balloon)
        {
            BalloonTypes currentBallonType = ((IBalloon)this.PlayGround.Field[balloon.Row, balloon.Column]).Type;
            balloon.Type = currentBallonType;

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
                    if (!this.AllocatePopingByDirection(baseBalloon, (Directions)direction))
                    {
                        break;
                    }
                }
            }

            Utils.SetBalloonToGameBoard(this, balloon, BalloonTypes.Deflated);
            this.ItemsCount--;

            this.ShootCounter++;
            this.LandFlyingBaloons();
        }

        public void Action(IGameEngine engine, CommandTypes type, string input = null)
        {
            switch (type)
            {
                case CommandTypes.Top:
                    engine.ViewScore();
                    break;
                case CommandTypes.Restart:
                    engine.NewGame();
                    engine.ShowGameBoard();
                    break;
                case CommandTypes.Exit:
                    engine.Quit();
                    break;
                case CommandTypes.Shoot:
                    IBalloon balloon = Utils.ParseBalloon(input);
                    this.Shoot(balloon);
                    engine.ShowGameBoard();
                    break;
                default:
                    throw new ArgumentException("Command value is not correct");
            }
        }

        private bool IsPopNeighbourSuccessful(BalloonTypes balloonType, IBalloon neighbourBalloon)
        {
            if (balloonType == ((IBalloon)this.PlayGround.Field[neighbourBalloon.Row, neighbourBalloon.Column]).Type)
            {
                Utils.SetBalloonToGameBoard(this, neighbourBalloon, BalloonTypes.Deflated);
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

                if (this.IsPopNeighbourSuccessful(balloon.Type, neighbourBalloon))
                {
                    balloon.ChangePositionByDirection(isMoveUpDown, value);

                    return true;
                }
            }
            catch (ArgumentException)
            {
            }

            return false;
        }

        private bool AllocatePopingByDirection(IBalloon balloon, Directions direction)
        {
            if (direction == Directions.Up)
            {
                return this.TryPopNeighbours(true, -1, balloon);
            }

            if (direction == Directions.Down)
            {
                return this.TryPopNeighbours(true, 1, balloon);
            }

            if (direction == Directions.Left)
            {
                return this.TryPopNeighbours(false, -1, balloon);
            }

            if (direction == Directions.Right)
            {
                return this.TryPopNeighbours(false, 1, balloon);
            }

            return false;
        }

        private void SwapBalloons(IBalloon firstBalloon, IBalloon secondBalloon)
        {
            firstBalloon.Type = secondBalloon.Type;
            secondBalloon.Type = BalloonTypes.Deflated;

            Utils.SetBalloonToGameBoard(this, firstBalloon);
            Utils.SetBalloonToGameBoard(this, secondBalloon);
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
                                this.SwapBalloons(deflatedBalloon, upperOfDeflatedBalloon);
                            }
                        }
                    }
                }
            }
        }
    }
}