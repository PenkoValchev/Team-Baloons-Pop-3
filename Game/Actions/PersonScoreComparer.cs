using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalloonsPops.Game.Entities;

namespace BalloonsPops.Game.Actions
{
    class PersonScoreComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}
