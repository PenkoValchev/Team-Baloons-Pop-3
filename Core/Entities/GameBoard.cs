namespace BalloonsPops.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BalloonsPops.Core.Actions;

    public sealed class GameBoard
    {
        private const int GAME_BOARD_WIDTH = 25;
        private const int GAME_BOARD_HEIGHT = 8;
        public const int INITIAL_BALLOONS_COUNT = 50;

        private char[,] _gameBoard;
        private int count = 0;
        private int _balloonsCount = INITIAL_BALLOONS_COUNT;

        private static readonly GameBoard _gameBoardInstance = new GameBoard();

        private GameBoard()
        {
            _gameBoard = new char[GAME_BOARD_WIDTH, GAME_BOARD_HEIGHT];
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
                return this._gameBoard.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return this._gameBoard.GetLength(1);
            }
        }

        public char[,] Board
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
                return count;
            }
        }

        public void Shoot(Balloon balloon)
        {
            char currentBaloon;
            currentBaloon = Get(balloon);
            Balloon tempCoordinates = new Balloon();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!"); return;
            }

            AddNewBaloonToGameBoard(balloon, '.');
            this.BalloonsCount--;


            //TODO: This logic check if it's possible to shoot neighbours balloons but don't check for out of range exception
            //Should be changed!!!

            tempCoordinates.Column = balloon.Column - 1;
            tempCoordinates.Row = balloon.Row;
            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.BalloonsCount--;
                tempCoordinates.Column--;
            }

            tempCoordinates.Column = balloon.Column + 1; tempCoordinates.Row = balloon.Row;
            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.BalloonsCount--;
                tempCoordinates.Column++;
            }

            tempCoordinates.Column = balloon.Column;
            tempCoordinates.Row = balloon.Row - 1;
            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.BalloonsCount--;
                tempCoordinates.Row--;
            }

            tempCoordinates.Column = balloon.Column;
            tempCoordinates.Row = balloon.Row + 1;
            while (currentBaloon == Get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                this.BalloonsCount--;
                tempCoordinates.Row++;
            }

            count++;
            LandFlyingBaloons();
        }

        //TODO: Think about right position of this method 
        public void AddNewBaloonToGameBoard(Balloon balloon, char value)
        {
            int xPosition = 4 + balloon.Column * 2;
            int yPosition = 2 + balloon.Row;
            _gameBoard[xPosition, yPosition] = value;
        }

        private char Get(Balloon c)
        {
            int xPosition, yPosition;
            if (c.Column < 0 || c.Row < 0 || c.Column > 9 || c.Row > 4) return 'e';
            xPosition = 4 + c.Column * 2;


            yPosition = 2 + c.Row;
            return _gameBoard[xPosition, yPosition];
        }

        private void Swap(Balloon c, Balloon c1)
        {
            char tmp = Get(c);
            AddNewBaloonToGameBoard(c, Get(c1));
            AddNewBaloonToGameBoard(c1, tmp);
        }

        private void LandFlyingBaloons()
        {

            for (int col = 0; col < 10; col++)
            {
                for (int row = 0; row <= 4; row++)
                {
                    Balloon balloon = new Balloon(row, col);

                    if (Get(balloon) == '.')
                    {
                        for (int k = row; k > 0; k--)
                        {
                            Balloon tempCoordinates = new Balloon(k, col);
                            Balloon tempCoordinates1 = new Balloon(k - 1, col);
                            Swap(tempCoordinates, tempCoordinates1);
                        }
                    }
                }
            }
        }
    }
}