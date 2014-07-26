namespace BalloonsPop.Common.Contracts
{
    using System;
    using BalloonsPop.Common.Components;

    public interface IBalloon : IPlayGroundItem
    {
        BalloonTypes Type { get; set; }
    }
}