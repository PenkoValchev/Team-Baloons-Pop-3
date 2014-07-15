namespace BalloonsPops.Common.Actions
{
    ﻿using BalloonsPops.Common.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class PersonScoreComparer : IComparer<IPlayer>
    {
        public int Compare(IPlayer x, IPlayer y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}