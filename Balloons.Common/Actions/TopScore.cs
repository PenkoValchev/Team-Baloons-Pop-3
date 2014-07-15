namespace BalloonsPops.Common.Actions
{
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class TopScore
    {
        public const int TOP_SCORE_LIMIT = 5;
        List<IPlayer> topScoreList = new List<IPlayer>();

        public bool IsTopScore(IPlayer person)
        {
            if (topScoreList.Count >= TOP_SCORE_LIMIT)
            {
                PersonScoreComparer comparer = new PersonScoreComparer();
                topScoreList.Sort(comparer);

                Player player = person as Player;
                Player playerWithMaxScore = topScoreList[TOP_SCORE_LIMIT - 1] as Player;
                if (playerWithMaxScore > player)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void AddToTopScoreList(IPlayer person)
        {
            topScoreList.Add(person);
            PersonScoreComparer comparer = new PersonScoreComparer();
            topScoreList.Sort(comparer);
            while (topScoreList.Count > TOP_SCORE_LIMIT)
            {
                topScoreList.RemoveAt(TOP_SCORE_LIMIT);
            }
        }

        public void OpenTopScoreList()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BalloonsPops.Common.Content.TopScore.txt"))
            {
                using (StreamReader topScoreReader = new StreamReader(stream))
                {
                    string line = topScoreReader.ReadLine();
                    while (line != null)
                    {
                        char[] separators = { ' ' };
                        string[] playerList = line.Split(separators);
                        int palyersCount = playerList.Count<string>();
                        if (palyersCount > 0)
                        {
                            string playerName = playerList[1];
                            int playerScore = int.Parse(playerList[palyersCount - 2]);
                            Player player = new Player(playerName, playerScore);
                            topScoreList.Add(player);
                        }
                        line = topScoreReader.ReadLine();
                    }
                }
            }
        }

        public void SaveTopScoreList()
        {
            if (topScoreList.Count > 0)
            {
                string toWrite = "";

                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BalloonsPops.Common.Content.TopScore.txt"))
                {
                    using (StreamWriter topScoreWriter = new StreamWriter(stream))
                    {
                        for (int i = 0; i < topScoreList.Count; i++)
                        {
                            toWrite += i.ToString() + ". " + topScoreList[i].Name + " --> " + topScoreList[i].Score.ToString() + " moves";
                            topScoreWriter.WriteLine(toWrite);
                            toWrite = "";
                        }
                    }
                }
            }
            PrintScoreList();
        }

        public void PrintScoreList()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Scoreboard:");
            builder.AppendLine();

            if (topScoreList.Count > 0)
            {
                for (int i = 0; i < topScoreList.Count; i++)
                {
                    builder.AppendFormat(string.Format("{0}. {1} --> {2}  moves", i + 1, topScoreList[i].Name, topScoreList[i].Score));
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
