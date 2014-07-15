namespace BalloonsPops.Common.Interfaces
{
    using System;
    using BalloonsPops.Common.Entities;

    public interface IBalloon
    {
        int Row { get; set; }

        int Column { get; set; }

        BalloonTypes Type { get; set; }

        void ChangePositionByDirection(bool isMoveUpDown, int value);
    }
}