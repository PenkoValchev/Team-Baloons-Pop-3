namespace BalloonsPops.Common.Components.Patterns
{
    using System.Collections.Generic;
    using BalloonsPops.Common.Interfaces;

    public class ScoreBoardProxy : IScoreBoard
    {
        private const int SCORE_BOARD_LIMIT = 5;
        private ScoreBoard realScoreBoard;

        public IList<IPlayer> ScoreBoardList
        {
            get
            {
                var scoreBoardList = new List<IPlayer>(this.ScoreBoard.ScoreList);
                return scoreBoardList;
            }
        }

        private ScoreBoard ScoreBoard
        {
            get
            {
                if (this.realScoreBoard == null)
                {
                    this.realScoreBoard = ScoreBoard.Instance;
                }

                return this.realScoreBoard;
            }
        }

        /// <summary>
        /// Adding specific player to the scoroboard list
        /// </summary>
        /// <param name="player">Instance of IPlayer</param>
        public void AddPlayer(IPlayer player)
        {
            if (this.IsTopScore(player))
            {
                var scoreBoardItems = this.ScoreBoard.ScoreList;
                scoreBoardItems.Add(player);
                ((List<IPlayer>)scoreBoardItems).Sort();

                while (scoreBoardItems.Count > SCORE_BOARD_LIMIT)
                {
                    this.RemovePlayer(scoreBoardItems[SCORE_BOARD_LIMIT]);
                }
            }
        }

        /// <summary>
        /// Removing specific player to the scoreboard list
        /// </summary>
        /// <param name="player">Instance of IPlayer</param>
        /// <returns>Returns true if removing is successful or false if it's not</returns>
        public bool RemovePlayer(IPlayer player)
        {
            return this.ScoreBoard.ScoreList.Remove(player);
        }

        /// <summary>
        /// Check if player has bigger score than the last player in scoreboard list 
        /// </summary>
        /// <param name="player">Instance of IPlayer</param>
        /// <returns>Returns true if player can be in scoreboard list and false if he can't</returns>
        public bool IsTopScore(IPlayer player)
        {
            var scoreBoardItems = this.ScoreBoard.ScoreList;
            int scoreBoardCount = scoreBoardItems.Count;

            if (scoreBoardCount >= SCORE_BOARD_LIMIT)
            {
                ((List<IPlayer>)scoreBoardItems).Sort();
                IPlayer lastPlayerInScoreList = scoreBoardItems[SCORE_BOARD_LIMIT - 1];

                var compareResult = lastPlayerInScoreList.CompareTo(player);

                if (compareResult > 0)
                {
                    return true;
                }

                return false;
            }

            return true;
        }
    }
}