namespace BalloonsPops.Entities
{
    using System;

    public class Player
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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name value should have at least one symbol.");
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