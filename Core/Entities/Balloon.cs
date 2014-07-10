namespace BalloonsPops.Core.Entities
{
    using System;
    using System.Linq;

    public class Balloon
    {
        private const int MAX_COLUMN_VALUE = 9;
        private const int MAX_ROW_VALUE = 4;
        private const int MIN_VALUE = 0;

        private int _column;
        private int _row;

        public Balloon() { }

        public int Column
        {
            get
            {
                return this._column;
            }
            set
            {
                if (MIN_VALUE > value || value > MAX_COLUMN_VALUE)
                {
                    throw new ArgumentException("Wrong column value for the Balloon");
                }

                this._column = value;
            }
        }

        public int Row
        {
            get
            {
                return this._row;
            }
            set
            {
                if (MIN_VALUE > value || value > MAX_ROW_VALUE)
                {
                    throw new ArgumentException("Wrong row value for the Balloon");
                }

                this._row = value;
            }
        }

        public static bool TryParse(string input, ref Balloon result)
        {
            char[] separators = { ' ', ',' };

            string[] substrings = input.Split(separators);

            if (substrings.Count<string>() != 2)
            {
                Console.WriteLine("Invalid move or command!");
                return false;
            }

            string coordinate = substrings[1].Trim();
            int x;
            if (int.TryParse(coordinate, out x))
            {
                if (x >= 0 && x <= 9)
                {
                    result.Column = x;
                }
                else
                {
                    Console.WriteLine("Wrong x coordinates");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid move or command!");
                return false;
            }

            coordinate = substrings[0].Trim();
            int y;
            if (int.TryParse(coordinate, out y))
            {
                if (y >= 0 && y <= 4)
                {
                    result.Row = y;
                }
                else
                {
                    Console.WriteLine("Wrong y coordinates");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid move or command!");
                return false;
            }

            return true;
        }
    }
}
