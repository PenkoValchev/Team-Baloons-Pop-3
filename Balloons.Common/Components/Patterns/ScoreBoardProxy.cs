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
                    this.realScoreBoard = new ScoreBoard();
                }

                return this.realScoreBoard;
            }
        }

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

        public bool RemovePlayer(IPlayer player)
        {
            return this.ScoreBoard.ScoreList.Remove(player);
        }

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