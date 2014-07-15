namespace BalloonsPops.Common.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Interfaces;

    public sealed class GameBoard
    {
        private const int GAME_BOARD_WIDTH = 10;
        private const int GAME_BOARD_HEIGHT = 5;
        public const int INITIAL_BALLOONS_COUNT = 50;

        //TODO change underscore for private fields 

        private IBalloon[,] _gameBoard;
        private int shootCounts = 0;
        private int _balloonsCount = INITIAL_BALLOONS_COUNT;

        private static readonly GameBoard _gameBoardInstance = new GameBoard();

        private GameBoard()
        {
            _gameBoard = new Balloon[GAME_BOARD_HEIGHT, GAME_BOARD_WIDTH];
            this.BalloonsCount = INITIAL_BALLOONS_COUNT;
            GenerateContent();
        }

        public static GameBoard Instance
        {
            get
            {
                return _gameBoardInstance;
            }
        }

        public int Width
        {
            get
            {
                return this._gameBoard.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return this._gameBoard.GetLength(0);
            }
        }

        public IBalloon[,] Board
        {
            get
            {
                return this._gameBoard;
            }
            set
            {
                this._gameBoard = value;
            }
        }

        public int BalloonsCount
        {
            get
            {
                return this._balloonsCount;
            }
            set
            {
                this._balloonsCount = value;
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
            BalloonTypes currentBallonType = this.Board[balloon.Row, balloon.Column].Type;

            if (currentBallonType == BalloonTypes.Deflated)
            {
                throw new InvalidOperationException("Wrong move: Cannot pop missing balloon!");
            }

            var directionsValues = Enum.GetValues(typeof(Directions));

            foreach (var direction in directionsValues)
            {

                IBalloon baseBalloon = (IBalloon)balloon.Clone();
                while (true)
                {
                    if (!AllocatePopingByDirection(baseBalloon, (Directions)direction))
                    {
                        break;
                    }
                }
            }

            SetBalloonToGameBoard(balloon, BalloonTypes.Deflated);
            this.BalloonsCount--;

            shootCounts++;
            LandFlyingBaloons();
        }

        private bool IsPopNeighbourSuccessful(BalloonTypes balloonType, IBalloon neighbourBalloon)
        {
            if (balloonType == this.Board[neighbourBalloon.Row, neighbourBalloon.Column].Type)
            {
                SetBalloonToGameBoard(neighbourBalloon, BalloonTypes.Deflated);
                this.BalloonsCount--;

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

        //TODO: Think about right position of this method 
        public void SetBalloonToGameBoard(IBalloon balloon, BalloonTypes balloonType)
        {
            balloon.Type = balloonType;
            SetBalloonToGameBoard(balloon);
        }

        public void SetBalloonToGameBoard(IBalloon balloon)
        {
            this.Board[balloon.Row, balloon.Column] = balloon;
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
            for (int row = 0; row < GAME_BOARD_HEIGHT; row++)
            {
                for (int col = 0; col < GAME_BOARD_WIDTH; col++)
                {
                    if (this.Board[row, col].Type == BalloonTypes.Deflated)
                    {
                        for (int swapingRow = row; swapingRow > 0; swapingRow--)
                        {
                            IBalloon upperOfDeflatedBalloon = this.Board[swapingRow - 1, col];

                            if (upperOfDeflatedBalloon.Type != BalloonTypes.Deflated)
                            {
                                IBalloon deflatedBalloon = this.Board[swapingRow, col];
                                SwapBalloons(deflatedBalloon, upperOfDeflatedBalloon);
                            }
                        }
                    }
                }
            }
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
            var randomNumber = Utils.random.Next(0, 4);
            return (BalloonTypes)randomNumber;
        }
    }
}