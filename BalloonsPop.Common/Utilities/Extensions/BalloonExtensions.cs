namespace BalloonsPop.Common.Utilities.Extensions
{
    using BalloonsPop.Common.Interfaces;

    internal static class BalloonExtensions
    {
        public static void ChangePositionByDirection(this IBalloon balloon, bool isMoveUpDown, int value)
        {
            if (isMoveUpDown)
            {
                balloon.Row += value;
            }
            else
            {
                balloon.Column += value;
            }
        }
    }
}