﻿namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Actions;
    using BalloonsPops.Common.Interfaces;
    using System.Collections.Generic;

    public class ScoreBoardProxy : IScoreBoard
    {
        private const int SCORE_BOARD_LIMIT = 5;
        private ScoreBoard realScoreBoard;

        public ScoreBoardProxy()
        { }

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
                if (realScoreBoard == null)
                {
                    realScoreBoard = new ScoreBoard();
                }

                return realScoreBoard;
            }
        }

        public void AddPlayer(IPlayer player)
        {
            if (IsTopScore(player))
            {
                var scoreBoardItems = this.ScoreBoard.ScoreList;
                scoreBoardItems.Add(player);
                ((List<IPlayer>)scoreBoardItems).Sort(Player.Compare);

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
                ((List<IPlayer>)scoreBoardItems).Sort(Player.Compare);
                IPlayer lastPlayerInScoreList = scoreBoardItems[SCORE_BOARD_LIMIT - 1];

                return lastPlayerInScoreList.ScoreCompare(player);
            }

            return true;
        }
    }
}