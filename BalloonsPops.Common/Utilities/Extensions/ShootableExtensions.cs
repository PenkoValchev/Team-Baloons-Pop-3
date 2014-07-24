namespace BalloonsPops.Common.Utilities.Extensions
{
    using System;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Interfaces;

    public static class ShootableExtensions
    {
        /// <summary>
        /// Extension method for Shootable. Specific action to perform when using shootable board. 
        /// </summary>
        /// <param name="shootable"></param>
        /// <param name="engine">Engine to hold the specific actions</param>
        /// <param name="type">Comman type to separate the actions</param>
        /// <param name="input"></param>
        public static void Action(this Shootable shootable, IGameEngine engine, CommandTypes type, string input = null)
        {
            switch (type)
            {
                case CommandTypes.Top:
                    engine.ViewScore();
                    break;
                case CommandTypes.Restart:
                    engine.NewGame();
                    engine.ShowGameBoard();
                    break;
                case CommandTypes.Exit:
                    engine.Quit();
                    break;
                case CommandTypes.Shoot:
                    ShootAction(shootable, engine, input);
                    break;
                default:
                    throw new ArgumentException("Command value is not correct");
            }
        }

        private static void ShootAction(this Shootable shootable, IGameEngine engine, string input)
        {
            IBalloon balloon = Utils.ParseBalloon(input);
            if (shootable.Shoot(balloon))
            {
                engine.GameResult++;
                if (shootable.ItemsCount <= 0)
                {
                    engine.IsGameOn = false;
                }
            }

            engine.ShowGameBoard();
        }
    }
}