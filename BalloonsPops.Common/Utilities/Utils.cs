namespace BalloonsPops.Common.Utilities
{
    using System;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;

    public static class Utils
    {
        /// <summary>
        /// Try to parse balloon from string input
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns>Instance of IBalloon</returns>
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

        /// <summary>
        /// Check if the specific command is shoot command
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns>True if it's shoot command</returns>
        public static bool IsShootCommand(string input)
        {
            CommandTypes currentType;

            int inputAsInt;
            bool isInputInteger = int.TryParse(input, out inputAsInt);

            if (!isInputInteger)
            {
                bool isCorrectEnum = Enum.TryParse(input, true, out currentType);

                if (isCorrectEnum)
                {
                    return false;
                }
            }

            return true;
        }

        internal static void SetBalloonToGameBoard(PlayGround playgroung, IBalloon balloon, BalloonTypes balloonType)
        {
            balloon.Type = balloonType;
            SetBalloonToGameBoard(playgroung, balloon);
        }

        internal static void SetBalloonToGameBoard(PlayGround playgroung,  IBalloon balloon)
        {
            playgroung.Field[balloon.Row, balloon.Column] = balloon;
        }
    }
}