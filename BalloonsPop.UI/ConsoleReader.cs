namespace BalloonsPops.UI
{
    using BalloonsPops.Common.Interfaces;
    using System;

    internal class ConsoleReader: IGameReader
    {
        public T Read<T>()
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            return (T)Convert.ChangeType(consoleInput, typeof(T));
        }
    }
}