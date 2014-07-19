namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Interfaces;
    using System;

    public class Player : IPlayer
    {
        private const string UNKNOWN_PLAYER_NAME = "Unknown";

        private string name;
        private int score;

        public Player(string name)
            : this(name, 0)
        { }

        public Player(int score)
            : this(UNKNOWN_PLAYER_NAME, score)
        { }

        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name could not be empty or null!");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name could not be only whitespace!");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Name could not be less 2 letters!");
                }

                this.name = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score can't be less than zero.");
                }

                this.score = value;
            }
        }

        public bool ScoreCompare(IPlayer player)
        {
            return this.Score > player.Score;
        }

        public static int Compare(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            return firstPlayer.Score.CompareTo(secondPlayer.Score);
        }
    }
}