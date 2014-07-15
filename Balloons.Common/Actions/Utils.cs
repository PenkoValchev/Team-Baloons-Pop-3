using BalloonsPops.Common.Entities;
namespace BalloonsPops.Common.Actions
{
    using BalloonsPops.Common.Interfaces;
    using System;

    public class Utils
    {
        public static Random random = new Random();

        public static IBalloon ParseBalloon(string input)
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
    }
}