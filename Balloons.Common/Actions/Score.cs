namespace BalloonsPops.Common.Actions
{
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public static class Score
    {
        private const int SCORE_LIST_LIMIT = 5;
        private const string SCORE_RESOURCE = "BalloonsPops.Common.Content.TopScore.txt";

        private static IList<IPlayer> scoreList = new List<IPlayer>();

        public static bool TryAddItem(IPlayer player)
        {
            if (IsTopScore(player))
            {
                scoreList.Add(player);

                ((List<IPlayer>)scoreList).Sort(Player.Compare);

                while (scoreList.Count > SCORE_LIST_LIMIT)
                {
                    scoreList.RemoveAt(SCORE_LIST_LIMIT);
                }

                return true;
            }

            return false;
        }

        public static void AddItem(IPlayer player)
        {
            scoreList.Add(player);
        }

        public static IList<IPlayer> GetItems()
        {
            IList<IPlayer> copyScoreList = new List<IPlayer>(scoreList);
            return copyScoreList;
        }

        private static bool IsTopScore(IPlayer player)
        {
            if (scoreList.Count >= SCORE_LIST_LIMIT)
            {
                ((List<IPlayer>)scoreList).Sort(Player.Compare);

                IPlayer lastPlayerInScoreList = scoreList[SCORE_LIST_LIMIT - 1];

                return lastPlayerInScoreList.ScoreCompare(player);
            }

            return true;
        }
    }
}