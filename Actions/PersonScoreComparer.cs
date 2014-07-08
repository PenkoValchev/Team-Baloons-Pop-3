using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalloonsPops.Entities;

namespace BalloonsPops.Actions
{
    class PersonScoreComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}
