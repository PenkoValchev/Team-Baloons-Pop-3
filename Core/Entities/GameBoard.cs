﻿namespace BalloonsPops.Core.Entities
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

        private char[,] _gameBoard;
        private int count = 0;
        private int balloonsCount = 50;

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
        }

        public void SetGameBoardValues(char boardValue) 
        {
            throw new NotImplementedException();
        }

        public int ShootCounter
        {
            get
            {
                return count;
            }
        }

        public int RemainingBaloons
        {
            get
            {
                return balloonsCount;
            }
        }

        public void GenerateNewGame()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            balloonsCount = 50;
            FillBlankGameBoard();
            Random random = new Random();
            Balloon c = new Balloon();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    c.Column = i;
                    c.Row = j;


                    AddNewBaloonToGameBoard(c, (char)(random.Next(1, 5) + (int)'0'));
                }
            }
        }

        public void Shoot(Balloon balloon)
        {
            char currentBaloon;
            currentBaloon = get(balloon);
            Balloon tempCoordinates = new Balloon();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!"); return;
            }

            AddNewBaloonToGameBoard(balloon, '.');
            balloonsCount--;

            tempCoordinates.Column = balloon.Column - 1;
            tempCoordinates.Row = balloon.Row;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                balloonsCount--;
                tempCoordinates.Column--;
            }

            tempCoordinates.Column = balloon.Column + 1; tempCoordinates.Row = balloon.Row;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                balloonsCount--;
                tempCoordinates.Column++;
            }

            tempCoordinates.Column = balloon.Column;
            tempCoordinates.Row = balloon.Row - 1;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                balloonsCount--;
                tempCoordinates.Row--;
            }

            tempCoordinates.Column = balloon.Column;
            tempCoordinates.Row = balloon.Row + 1;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                balloonsCount--;
                tempCoordinates.Row++;
            }

            count++;
            LandFlyingBaloons();
        }

        public bool ReadInput(out bool IsCoordinates, ref Balloon coordinates, ref Command command)
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            coordinates = new Balloon();
            command = new Command();

            if (Command.TryParse(consoleInput, ref command))
            {
                IsCoordinates = false;
                return true;
            }
            else if (Balloon.TryParse(consoleInput, ref coordinates))
            {
                IsCoordinates = true;
                return true;
            }


            else
            {
                IsCoordinates = false;
                return false;
            }
        }

        private void AddNewBaloonToGameBoard(Balloon c, char value)
        {
            int xPosition, yPosition;
            xPosition = 4 + c.Column * 2;
            yPosition = 2 + c.Row;
            _gameBoard[xPosition, yPosition] = value;
        }

        private char get(Balloon c)
        {
            int xPosition, yPosition;
            if (c.Column < 0 || c.Row < 0 || c.Column > 9 || c.Row > 4) return 'e';
            xPosition = 4 + c.Column * 2;


            yPosition = 2 + c.Row;
            return _gameBoard[xPosition, yPosition];
        }

        private void FillBlankGameBoard()
        {
            //printing blank spaces
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 25; j++)
                {

                    _gameBoard[j, i] = ' ';
                }
            }

            //printing firs row
            for (int i = 0; i < 4; i++)
            {
                _gameBoard[i, 0] = ' ';
            }

            char counter = '0';


            for (int i = 4; i < 25; i++)
            {
                if ((i % 2 == 0) && counter <= '9') _gameBoard[i, 0] = (char)counter++;
                else _gameBoard[i, 0] = ' ';
            }

            //printing second row
            for (int i = 3; i < 24; i++)
            {
                _gameBoard[i, 1] = '-';
            }


            //printing left game board wall
            counter = '0';

            for (int i = 2; i < 8; i++)
            {
                if (counter <= '4')
                {
                    _gameBoard[0, i] = counter++;
                    _gameBoard[1, i] = ' ';


                    _gameBoard[2, i] = '|';
                    _gameBoard[3, i] = ' ';
                }
            }

            //printing down game board wall
            for (int i = 3; i < 24; i++)
            {
                _gameBoard[i, 7] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < 7; i++)
            {
                _gameBoard[24, i] = '|';
            }
        }

        private void Swap(Balloon c, Balloon c1)
        {
            char tmp = get(c);
            AddNewBaloonToGameBoard(c, get(c1));
            AddNewBaloonToGameBoard(c1, tmp);


        }

        private void LandFlyingBaloons()
        {
            Balloon c = new Balloon();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    c.Column = i;
                    c.Row = j;
                    if (get(c) == '.')
                    {
                        for (int k = j; k > 0; k--)
                        {
                            Balloon tempCoordinates = new Balloon();
                            Balloon tempCoordinates1 = new Balloon();
                            tempCoordinates.Column = i;
                            tempCoordinates.Row = k;
                            tempCoordinates1.Column = i;
                            tempCoordinates1.Row = k - 1;
                            Swap(tempCoordinates, tempCoordinates1);
                        }
                    }
                }


            }
        }
    }
}