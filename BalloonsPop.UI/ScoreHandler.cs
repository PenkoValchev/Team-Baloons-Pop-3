namespace BalloonsPops.UI
{
    using System;
    using System.Linq;
    using System.Text;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;

    internal static class ScoreHandler
    {
        private const string ENTER_PLAYER_NAME = "Please enter your name for the top scoreboard: ";
        private const string SCORE_BOARD = "Scoreboard:";
        private const string EMPTY_SCORE_BOARD = "The scoreboard is empty.";

        private static readonly ScoreBoardProxy scoreBoard = new ScoreBoardProxy();

        public static void TryAddToScoreBoard(int score)
        {
            IPlayer player = new Player(score);

            if (scoreBoard.IsTopScore(player))
            {
                Console.Write(ENTER_PLAYER_NAME);
                string playerName = Console.ReadLine();
                IPlayer topScorePlayer = new Player(playerName, score);
                scoreBoard.AddPlayer(topScorePlayer);
            }
        }

        public static void PrintScoreBoard()
        {
            var scoreList = scoreBoard.ScoreBoardList;

            StringBuilder builder = new StringBuilder();

            if (scoreList.Count > 0)
            {
                builder.Append(SCORE_BOARD);
                builder.AppendLine();

                for (int i = 0; i < scoreList.Count; i++)
                {
                    builder.AppendFormat(string.Format("{0}. {1} --> {2}  moves", i + 1, scoreList[i].Name, scoreList[i].Score));
                    builder.AppendLine();
                }
            }
            else
            {
                builder.Append(EMPTY_SCORE_BOARD);
                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}