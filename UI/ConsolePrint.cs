namespace BalloonsPops.UI
{
    using BalloonsPops.Core.Actions;
    using BalloonsPops.Core.Entities;
    using System;
    using System.Text;

    public static class ConsolePrint
    {
        private const string BALLOON_GAME_WELCOME_MESSAGE = "Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

        private static GameBoard _gameBoard = GameBoard.Instance;

        private static string PrintBorder()
        {
            StringBuilder border = new StringBuilder();
            border.Append(new String(' ', 3));
            border.Append(new String('-', 21));
            border.AppendLine();

            return border.ToString();
        }

        private static char ParseBalloonToChar(BalloonTypes balloonType)
        {
            switch (balloonType)
            {
                case BalloonTypes.Red:
                    return '1';
                case BalloonTypes.Green:
                    return '2';
                case BalloonTypes.Blue:
                    return '3';
                case BalloonTypes.Yellow:
                    return '4';
                case BalloonTypes.Deflated:
                    return '.';
                default:
                    throw new ArgumentException("Wrong balloon type.");
            }
        }

        private static string PrintGameFieldHeader()
        {
            StringBuilder header = new StringBuilder();
            //Header
            header.AppendLine();
            header.Append(new String(' ', 4));
            int counter = 0;
            for (int i = 0, len = _gameBoard.Width * 2; i < len; i++)
            {
                if (i % 2 != 0)
                {
                    header.Append(' ');
                }
                else
                {
                    header.Append(counter);
                    counter++;
                }
            }
            header.AppendLine();
            header.Append(PrintBorder());

            return header.ToString();
        }

        private static string PrintGameFieldBody()
        {
            StringBuilder body = new StringBuilder();
            for (int row = 0; row < _gameBoard.Height; row++)
            {
                body.Append(row);
                body.Append(' ');
                body.Append('|');
                var colCounter = 0;
                for (int j = 0, len = (int)(_gameBoard.Width * 2.5); j < len; j++)
                {
                    if (j % 2 == 0)
                    {
                        body.Append(' ');
                    }
                    else
                    {
                        char balloonType = ParseBalloonToChar(_gameBoard.Board[row, colCounter].Type);
                        body.Append(balloonType);
                        colCounter++;
                        if (colCounter >= _gameBoard.Width)
                        {
                            break;
                        }
                    }
                }
                body.AppendFormat("{0}{1}", ' ', '|');
                body.AppendLine();
            }

            body.Append(PrintBorder());

            return body.ToString();
        }

        public static void PrintGameBoard()
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(PrintGameFieldHeader());
            outPut.Append(PrintGameFieldBody());

            Console.WriteLine(outPut.ToString());
        }

        public static void GenerateNewGame()
        {
            Console.WriteLine(BALLOON_GAME_WELCOME_MESSAGE);
        }

        public static string ReadInput()
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            return consoleInput;
        }
    }
}