﻿namespace BalloonsPops.Common.Entities
{
    using BalloonsPops.Common.Interfaces;
    using System;

    public class Player : IPlayer
    {
        private string _name;
        private int _score;

        public Player(string name)
            : this(name, 0)
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
                return this._name;
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

                if (value.Length<2)
                {
                    throw new ArgumentException("Name could not be less 2 letters!");
                }

                this._name = value;
            }
        }

        public int Score
        {
            get
            {
                return this._score;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score can't be less than zero.");
                }

                this._score = value;
            }
        }

        public static bool operator <(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.Score < secondPlayer.Score;
        }

        public static bool operator >(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.Score > secondPlayer.Score;
        }
    }
}