namespace BalloonsPops.Common.Entities
{
    using System;
    using System.Linq;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Interfaces;
    using BalloonsPops.Common.Utilities;

    public sealed class BalloonBoard : PlayGround
    {
        private const int GAME_BOARD_WIDTH = 10;
        private const int GAME_BOARD_HEIGHT = 5;
        private const int BALLOON_TYPE_MAX_NUMBER = 3;

        private static BalloonBoard balloonBoardInstance;
        private IBalloon[,] balloonBoard;

        private BalloonBoard()
        {
            this.balloonBoard = new Balloon[GAME_BOARD_HEIGHT, GAME_BOARD_WIDTH];
            this.GenerateContent();
        }

        public static BalloonBoard Instance
        {
            get
            {
                if (balloonBoardInstance == null)
                {
                    balloonBoardInstance = new BalloonBoard();
                }

                return balloonBoardInstance;
            }
        }

        public int Width
        {
            get
            {
                return this.balloonBoard.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return this.balloonBoard.GetLength(0);
            }
        }

        public override IPlayGroundItem[,] Field
        {
            get
            {
                return this.balloonBoard;
            }

            set
            {
                this.balloonBoard = value as IBalloon[,];
            }
        }

        /// <summary>
        /// Generate and assign new content for the balloon board
        /// </summary>
        public void RePopulate()
        {
            this.GenerateContent();
        }

        private void GenerateContent()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    IBalloon balloon = new Balloon(row, col);
                    BalloonTypes balloonType = this.GenerateRandomBalloonType();
                    balloon.Type = balloonType;

                    Utils.SetBalloonToGameBoard(this, balloon);
                }
            }
        }

        private BalloonTypes GenerateRandomBalloonType()
        {
            var randomGenerator = new RandomGenerator();
            var randomNumber = randomGenerator.Next(0, BALLOON_TYPE_MAX_NUMBER);

            return (BalloonTypes)randomNumber;
        }
    }
}