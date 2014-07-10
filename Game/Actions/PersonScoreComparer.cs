using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalloonsPops.Game.Entities;
using BalloonsPops.Game.Interfaces;

namespace BalloonsPops.Game.Actions
{
    public class PersonScoreComparer : IComparer<IPlayer>
    {
        public int Compare(IPlayer x, IPlayer y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}
