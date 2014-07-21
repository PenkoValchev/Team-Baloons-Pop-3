namespace BalloonsPops.Common.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPops.Common.Interfaces;

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
            this.scoreList.Add(player);
        }

        public bool RemovePlayer(IPlayer player)
        {
            return this.scoreList.Remove(player);
        }
    }
}