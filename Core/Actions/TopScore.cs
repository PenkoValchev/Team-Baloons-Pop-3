namespace BalloonsPops.Core.Actions
{
    using BalloonsPops.Core.Entities;
    using BalloonsPops.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

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
                    string[] substrings = line.Split(separators);
                    int substringsCount = substrings.Count<string>();
                    if (substringsCount > 0)
                    {
                        string playerName = substrings[1];
                        int playerScore = int.Parse(substrings[substringsCount - 2]);
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
                using (StreamWriter TopScoreStreamWriter = new StreamWriter(@"..\..\Content\TopScore.txt"))
                {
                    for (int i = 0; i < topScoreList.Count; i++)
                    {
                        toWrite += i.ToString() + ". " + topScoreList[i].Name + " --> " + topScoreList[i].Score.ToString() + " moves";
                        TopScoreStreamWriter.WriteLine(toWrite);
                        toWrite = "";
                    }
                }
            }
            PrintScoreList();
        }

        public void PrintScoreList()
        {
            Console.WriteLine("Scoreboard:");
            if (topScoreList.Count > 0)
            {
                for (int i = 0; i < topScoreList.Count; i++)
                {
                    Console.WriteLine(i.ToString() + ". " + topScoreList[i].Name + " --> " + topScoreList[i].Score.ToString() + "moves");
                }
            }
            else
            {
                Console.WriteLine("Scoreboard is empty");
            }
        }
    }
}
