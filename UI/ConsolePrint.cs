namespace BalloonsPops.UI
{
    using BalloonsPops.Core.Entities;
    using System;

    public static class ConsolePrint
    {
        private const string BALLOON_GAME_WELCOME_MESSAGE = "Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

        private static GameBoard _gameBoard = GameBoard.Instance;

        public static void PrintGameBoard()
        {
            for (int i = 0; i < _gameBoard.Height; i++)
            {
                for (int j = 0; j < _gameBoard.Width; j++)
                {
                    Console.Write(_gameBoard.Board[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void GenerateNewGame()
        {
            Console.WriteLine(BALLOON_GAME_WELCOME_MESSAGE);
            _gameBoard.BalloonsCount = GameBoard.INITIAL_BALLOONS_COUNT;
            FillBlankGameBoard();
            Random random = new Random();
            Balloon c = new Balloon();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    c.Column = i;
                    c.Row = j;

                    _gameBoard.AddNewBaloonToGameBoard(c, (char)(random.Next(1, 5) + (int)'0'));
                }
            }
        }

        private static void FillBlankGameBoard()
        {
            var gameBoard = _gameBoard.Board;

            //printing blank spaces
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    gameBoard[j, i] = ' ';
                }
            }

            //printing firs row
            for (int i = 0; i < 4; i++)
            {
                gameBoard[i, 0] = ' ';
            }

            char counter = '0';


            for (int i = 4; i < 25; i++)
            {
                if ((i % 2 == 0) && counter <= '9') gameBoard[i, 0] = (char)counter++;
                else gameBoard[i, 0] = ' ';
            }

            //printing second row
            for (int i = 3; i < 24; i++)
            {
                gameBoard[i, 1] = '-';
            }

            //printing left game board wall
            counter = '0';

            for (int i = 2; i < 8; i++)
            {
                if (counter <= '4')
                {
                    gameBoard[0, i] = counter++;
                    gameBoard[1, i] = ' ';


                    gameBoard[2, i] = '|';
                    gameBoard[3, i] = ' ';
                }
            }

            //printing down game board wall
            for (int i = 3; i < 24; i++)
            {
                gameBoard[i, 7] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < 7; i++)
            {
                gameBoard[24, i] = '|';
            }
        }
    }
}