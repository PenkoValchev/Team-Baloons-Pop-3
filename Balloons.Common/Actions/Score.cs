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

        public static bool TryAdd(IPlayer player)
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

        public static void InitScoreList()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SCORE_RESOURCE))
            {
                using (StreamReader scoreReader = new StreamReader(stream))
                {
                    string line = scoreReader.ReadLine();

                    while (line != null)
                    {
                        char[] separators = { ' ' };
                        string[] playerList = line.Split(separators);
                        int palyersCount = playerList.Count<string>();

                        if (palyersCount > 0)
                        {
                            string playerName = playerList[1];
                            int playerScore = int.Parse(playerList[palyersCount - 2]);
                            IPlayer player = new Player(playerName, playerScore);
                            scoreList.Add(player);
                        }

                        line = scoreReader.ReadLine();
                    }
                }
            }
        }

        public static void Save()
        {
            if (scoreList.Count > 0)
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(SCORE_RESOURCE))
                {
                    using (StreamWriter scoreWriter = new StreamWriter(stream))
                    {
                        for (int i = 0; i < scoreList.Count; i++)
                        {
                            string scoreContent = String.Format("{0}. {1} --> {2} moves", i.ToString(), scoreList[i].Name, scoreList[i].Score.ToString());
                            scoreWriter.WriteLine(scoreContent);
                        }
                    }
                }
            }
        }

        public static IList<IPlayer> Get()
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