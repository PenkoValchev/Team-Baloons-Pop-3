namespace BalloonsPop.Common.Interfaces
{
    using System;
    using BalloonsPop.Common.Components;

    public interface IBalloon : IPlayGroundItem
    {
        BalloonTypes Type { get; set; }
    }
}