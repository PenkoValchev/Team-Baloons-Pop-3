﻿namespace BalloonsPop.Common.Entities
{
    using System;
    using BalloonsPop.Common.Contracts;

    public class Player : IPlayer
    {
        private const string UNKNOWN_PLAYER_NAME = "Unknown";
        private const int NAME_MIN_LENGTH = 2;

        private string name;
        private int score;

        public Player()
            : this(UNKNOWN_PLAYER_NAME)
        {
        }

        public Player(string name)
            : this(name, 0)
        {
        }

        public Player(int score)
            : this(UNKNOWN_PLAYER_NAME, score)
        {
        }

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

                if (value.Length < NAME_MIN_LENGTH)
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

        public int CompareTo(IPlayer other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}