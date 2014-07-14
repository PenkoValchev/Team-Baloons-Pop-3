namespace BalloonsPops.Core.Entities
{
    using System;
    using System.Linq;

    public class Balloon : ICloneable
    {
        private const int MAX_COLUMN_VALUE = 9;
        private const int MAX_ROW_VALUE = 4;
        private const int MIN_VALUE = default(int);

        private int column;
        private int row;

        public Balloon()
            : this(MIN_VALUE, MIN_VALUE)
        { }

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

        public static Balloon Parse(string input)
        {
            const int NUMBER_OF_ROWS = 4;
            const int NUMBER_OF_COLS = 9;
            int row, column;
            char[] separators = { ' ', ',', '.' };

            string[] coordinates = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (coordinates.Length != 2)
            {
                throw new InvalidOperationException("Invalid move or command!");
            }

            string rowInput = coordinates[0].Trim();

            if (!int.TryParse(rowInput, out row))
            {
                throw new InvalidOperationException("Invalid move or command!");
            }

            if (row < 0 && row > NUMBER_OF_ROWS)
            {
                throw new ArgumentException("Wrong row coordinates");
            }

            string columnInput = coordinates[1].Trim();
         

            if (!int.TryParse(columnInput, out column))
            {
                throw new InvalidOperationException("Invalid move or command!");
            }

            if (column < 0 || column > NUMBER_OF_COLS)
            {
                throw new ArgumentException("Wrong column value");
            }

            return new Balloon(row, column);
        }

        public void ChangePositionByDirection(bool isMoveUpDown, int value)
        {
            if (isMoveUpDown)
            {
                this.Row += value;
            }
            else
            {
                this.Column += value;
            }
        }

        public object Clone()
        {
            return new Balloon(this.Row,this.Column);
        }
    }
}