namespace BalloonsPops.Common.Interfaces
{
    using System;
    using BalloonsPops.Common.Entities;

    public interface IBalloon : IPlayGroundItem
    {
        BalloonTypes Type { get; set; }

        void ChangePositionByDirection(bool isMoveUpDown, int value);
    }
}