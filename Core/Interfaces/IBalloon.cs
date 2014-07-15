namespace BalloonsPops.Core.Interfaces
{
    using System;
    using BalloonsPops.Core.Entities;

    public interface IBalloon: ICloneable
    {
        int Row { get; set; }

        int Column { get; set; }

        BalloonTypes Type { get; set; }

        void ChangePositionByDirection(bool isMoveUpDown, int value);
    }
}