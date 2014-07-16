namespace BalloonsPops.UI
{
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;
    using System.Text;

    public static class ConsolePrint
    {
        private const string BALLOON_GAME_WELCOME_MESSAGE = "Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

        private static BalloonBoard balloonBoard = BalloonBoard.Instance;

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
            for (int i = 0, len = balloonBoard.Width * 2; i < len; i++)
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
            for (int row = 0; row < balloonBoard.Height; row++)
            {
                body.Append(row);
                body.Append(' ');
                body.Append('|');
                var colCounter = 0;
                for (int j = 0, len = (int)(balloonBoard.Width * 2.5); j < len; j++)
                {
                    if (j % 2 == 0)
                    {
                        body.Append(' ');
                    }
                    else
                    {
                        char balloonType = ParseBalloonToChar(((IBalloon)balloonBoard.Field[row, colCounter]).Type);
                        body.Append(balloonType);
                        colCounter++;
                        if (colCounter >= balloonBoard.Width)
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

        public static void PrintScoreList()
        {
            var scoreList = Score.GetItems();

            StringBuilder builder = new StringBuilder();
            builder.Append("Scoreboard:");
            builder.AppendLine();

            if (scoreList.Count > 0)
            {
                for (int i = 0; i < scoreList.Count; i++)
                {
                    builder.AppendFormat(string.Format("{0}. {1} --> {2}  moves", i + 1, scoreList[i].Name, scoreList[i].Score));
                    builder.AppendLine();
                }
            }
            else
            {
                builder.Append("Scoreboard is empty");
                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}