namespace BalloonsPops.UI
{
    using System;
    using BalloonsPops.Common.Interfaces;

    internal class ConsoleReader : IGameReader
    {
        public T Read<T>()
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            return (T)Convert.ChangeType(consoleInput, typeof(T));
        }
    }
}