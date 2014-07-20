namespace BalloonsPops.Common.Actions
{
    using BalloonsPops.Common.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ScoreBoard : IScoreBoard
    {
        private readonly IList<IPlayer> scoreList = new List<IPlayer>();

        internal IList<IPlayer> ScoreList 
        {
            get
            {
                return this.scoreList;
            }
        }

        public void AddPlayer(IPlayer player)
        {
            scoreList.Add(player);
        }

        public bool RemovePlayer(IPlayer player)
        {
            return scoreList.Remove(player);
        }
    }
}