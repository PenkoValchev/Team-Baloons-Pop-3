namespace BalloonsPopUI
{
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class ScoreHandler
    {
        //May Be Adapter or Proxy for here
        private const string SCORE_RESOURCE = @"../../Content/TopScore.txt";

        public static void InitScoreList()
        {
            using (StreamReader scoreReader = new StreamReader(SCORE_RESOURCE))
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
                        Score.AddItem(player);
                    }

                    line = scoreReader.ReadLine();
                }
            }
        }

        public static void Save()
        {
            var scoreItemsCount = Score.GetItems().Count;

            if (scoreItemsCount > 0)
            {
                var scoreItems = Score.GetItems();

                using (StreamWriter scoreWriter = new StreamWriter(SCORE_RESOURCE))
                {
                    for (int i = 0; i < scoreItemsCount; i++)
                    {
                        string scoreContent = String.Format("{0}. {1} --> {2} moves", i.ToString(), scoreItems[i].Name, scoreItems[i].Score.ToString());
                        scoreWriter.WriteLine(scoreContent);
                    }
                }
            }
        }
    }
}
