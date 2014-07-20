namespace BalloonsPops.Common.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Interfaces;

    public sealed class BalloonBoard : PlayGround
    {
        private const int GAME_BOARD_WIDTH = 10;
        private const int GAME_BOARD_HEIGHT = 5;

        private IBalloon[,] balloonBoard;

        private static readonly BalloonBoard balloonBoardInstance = new BalloonBoard();

        private BalloonBoard()
        {
            balloonBoard = new Balloon[GAME_BOARD_HEIGHT, GAME_BOARD_WIDTH];
            GenerateContent();
        }

        public static BalloonBoard Instance
        {
            get
            {
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

        public void RePopulate()
        {
            GenerateContent();
        }

        private void GenerateContent()
        {
            for (int row = 0; row < this.Height; row++)
            {
                for (int col = 0; col < this.Width; col++)
                {
                    IBalloon balloon = new Balloon(row, col);
                    BalloonTypes balloonType = GenerateRandomBalloonType();
                    balloon.Type = balloonType;

                    SetBalloonToGameBoard(balloon);
                }
            }
        }

        private BalloonTypes GenerateRandomBalloonType()
        {
            var randomGenerator = new RandomGenerator();
            var randomNumber = randomGenerator.Next(0, 3);

            return (BalloonTypes)randomNumber;
        }

        private void SetBalloonToGameBoard(IBalloon balloon)
        {
            this.Field[balloon.Row, balloon.Column] = balloon;
        }
    }
}