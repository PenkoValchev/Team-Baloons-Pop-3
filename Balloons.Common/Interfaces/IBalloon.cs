﻿namespace BalloonsPops.Common.Interfaces
{
    using System;
    using BalloonsPops.Common.Components;
    using BalloonsPops.Common.Entities;

    public interface IBalloon : IPlayGroundItem
    {
        BalloonTypes Type { get; set; }
    }
}