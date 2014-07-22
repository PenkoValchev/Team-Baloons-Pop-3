namespace BalloonsPops.Common.Entities
{
    using System;
    using System.Linq;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Interfaces;

    internal class Balloon : BalloonPrototype, IBalloon
    {
        private const int MAX_COLUMN_VALUE = 9;
        private const int MAX_ROW_VALUE = 4;
        private const int MIN_VALUE = default(int);

        private int column;
        private int row;

        public Balloon()
            : this(MIN_VALUE, MIN_VALUE)
        { 
        }

        public Balloon(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (MIN_VALUE > value || value > MAX_ROW_VALUE)
                {
                    throw new ArgumentException("Wrong row value for the Balloon");
                }

                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                if (MIN_VALUE > value || value > MAX_COLUMN_VALUE)
                {
                    throw new ArgumentException("Wrong column value for the Balloon");
                }

                this.column = value;
            }
        }

        public BalloonTypes Type { get; set; }

        public override Balloon Clone()
        {
            return this.MemberwiseClone() as Balloon;
        }
    }
}