namespace BalloonsPops.Common.Utilities.Extensions
{
    using System;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Components.Patterns;
    using BalloonsPops.Common.Interfaces;

    public static class ShootableExtensions
    {
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
                    IBalloon balloon = Utils.ParseBalloon(input);
                    shootable.Shoot(balloon);
                    engine.ShowGameBoard();
                    break;
                default:
                    throw new ArgumentException("Command value is not correct");
            }
        }
    }
}