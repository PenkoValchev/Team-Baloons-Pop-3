namespace BalloonsPops.UI
{
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;
    using System.Text;

    internal class ConsoleRender : IGameRender
    {
        private const string BALLOON_GAME_WELCOME_MESSAGE = "Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

        private readonly PlayGround playGround;

        public ConsoleRender(PlayGround playground)
        {
            playGround = playground;
        }

        public void ViewScore()
        {
            ScoreHandler.PrintScoreBoard();
        }

        public void StartNewGame()
        {
            Console.WriteLine(BALLOON_GAME_WELCOME_MESSAGE);
        }

        public void Quit()
        {
            Environment.Exit(0);
        }

        public void ShowGameBoard()
        {
            StringBuilder outPut = new StringBuilder();
            outPut.Append(PrintGameFieldHeader());
            outPut.Append(PrintGameFieldBody());

            Console.WriteLine(outPut.ToString());
        }

        public void GameOver<T>(T score)
        {
            int finalScore = Convert.ToInt32(score);
            ScoreHandler.TryAddToScoreBoard(finalScore);

            ScoreHandler.PrintScoreBoard();

            (BalloonBoard.Instance).RePopulate();
            Engine.StartGame();
        }

        public void ErrorHandler(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        private static string PrintBorder()
        {
            StringBuilder border = new StringBuilder();
            border.Append(new String(' ', 3));
            border.Append(new String('-', 21));
            border.AppendLine();

            return border.ToString();
        }

        private string PrintGameFieldHeader()
        {
            StringBuilder header = new StringBuilder();
            header.AppendLine();
            header.Append(new String(' ', 4));
            int counter = 0;

            for (int i = 0, len = this.playGround.Field.GetLength(1) * 2; i < len; i++)
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

        private string PrintGameFieldBody()
        {
            StringBuilder body = new StringBuilder();
            for (int row = 0; row < this.playGround.Field.GetLength(0); row++)
            {
                body.Append(row);
                body.Append(' ');
                body.Append('|');
                var colCounter = 0;

                for (int j = 0, len = (int)(this.playGround.Field.GetLength(1) * 2.5); j < len; j++)
                {
                    if (j % 2 == 0)
                    {
                        body.Append(' ');
                    }
                    else
                    {
                        char balloonType = ParseBalloonToChar(((IBalloon)this.playGround.Field[row, colCounter]).Type);
                        body.Append(balloonType);
                        colCounter++;
                        if (colCounter >= this.playGround.Field.GetLength(1))
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
    }
}