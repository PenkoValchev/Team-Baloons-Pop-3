namespace BalloonsPops.UI
{
    using BalloonsPops.Core.Entities;
    using System;

    public static class ConsolePrint
    {
        public static void PrintGameBoard()
        {
            GameBoard gameBoard = GameBoard.Instance;

            for (int i = 0; i < gameBoard.Height; i++)
            {
                for (int j = 0; j < gameBoard.Width; j++)
                {
                    Console.Write(gameBoard.Board[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}