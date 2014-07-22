namespace BalloonsPops.Common.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPops.Common.Interfaces;

    internal sealed class ScoreBoard : IScoreBoard
    {
        private static volatile ScoreBoard instance;
        private static object syncRoot = new Object();
        private readonly IList<IPlayer> scoreList = new List<IPlayer>();

        private ScoreBoard() { }

        internal static ScoreBoard Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ScoreBoard();
                        }
                    }
                }

                return instance;
            }
        }

        internal IList<IPlayer> ScoreList 
        {
            get
            {
                return this.scoreList;
            }
        }

        public void AddPlayer(IPlayer player)
        {
            this.scoreList.Add(player);
        }

        public bool RemovePlayer(IPlayer player)
        {
            return this.scoreList.Remove(player);
        }
    }
}