﻿namespace BalloonsPops.UI
{
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;
    using System.Linq;
    using System.Text;

    internal static class ScoreHandler
    {
        private const string ENTER_PLAYER_NAME = "Please enter your name for the top scoreboard: ";
        private const string SCORE_BOARD = "Scoreboard:";
        private const string EMPTY_SCORE_BOARD = "Scoreboard is empty";

        private static readonly ScoreBoardProxy scoreBoard = new ScoreBoardProxy();

        public static void TryAddToScoreBoard(int score)
        {
            IPlayer player = new Player(score);

            if (scoreBoard.IsTopScore(player))
            {
                Console.WriteLine(ENTER_PLAYER_NAME);
                string playerName = Console.ReadLine();
                IPlayer topScorePlayer = new Player(playerName, score);
                scoreBoard.AddPlayer(topScorePlayer);
            }
        }

        public static void PrintScoreBoard()
        {
            var scoreList = scoreBoard.ScoreBoardList;

            StringBuilder builder = new StringBuilder();
            builder.Append(SCORE_BOARD);
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
                builder.Append(EMPTY_SCORE_BOARD);
                builder.AppendLine();
            }

            Console.WriteLine(builder.ToString());
        }
    }
}