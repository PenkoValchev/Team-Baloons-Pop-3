namespace BalloonsPops.Core.Actions
{
    using BalloonsPops.Core.Entities;
    using BalloonsPops.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class TopScore
    {
        public const int MAX_TOP_SCORE_COUNT = 5;
        List<IPlayer> topScoreList = new List<IPlayer>();

        public bool IsTopScore(IPlayer person)
        {
            if (topScoreList.Count >= MAX_TOP_SCORE_COUNT)
            {
                PersonScoreComparer comparer = new PersonScoreComparer();
                topScoreList.Sort(comparer);

                Player player = person as Player;
                Player playerWithMaxScore = topScoreList[MAX_TOP_SCORE_COUNT - 1] as Player;
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
            while (topScoreList.Count > 5)
            {
                topScoreList.RemoveAt(5);
            }
        }

        public void OpenTopScoreList()
        {
            using (StreamReader topScoreStreamReader = new StreamReader(@"..\..\Content\TopScore.txt"))
            {
                string line = topScoreStreamReader.ReadLine();
                while (line != null)
                {
                    char[] separators = { ' ' };
                    string[] playerList = line.Split(separators);
                    int substringsCount = playerList.Count<string>();
                    if (substringsCount > 0)
                    {
                        string playerName = playerList[1];
                        int playerScore = int.Parse(playerList[substringsCount - 2]);
                        Player player = new Player(playerName, playerScore);
                        topScoreList.Add(player);
                    }
                    line = topScoreStreamReader.ReadLine();
                }
            }
        }

        public void SaveTopScoreList()
        {
            if (topScoreList.Count > 0)
            {
                string toWrite = "";
                using (StreamWriter topScoreStreamWriter = new StreamWriter(@"..\..\Content\TopScore.txt"))
                {
                    for (int i = 0; i < topScoreList.Count; i++)
                    {
                        toWrite += i.ToString() + ". " + topScoreList[i].Name + " --> " + topScoreList[i].Score.ToString() + " moves";
                        topScoreStreamWriter.WriteLine(toWrite);
                        toWrite = "";
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
            //Console.WriteLine("Scoreboard:");
            if (topScoreList.Count > 0)
            {
                for (int i = 0; i < topScoreList.Count; i++)
                {
                    builder.AppendFormat(string.Format("{0}. {1} --> {2}  moves", i+1, topScoreList[i].Name, topScoreList[i].Score));
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
