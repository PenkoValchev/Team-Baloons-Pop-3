namespace BalloonsPop.Common.Contracts
{
    using System;
    using System.Linq;

    public interface IPlayGroundItem
    {
        int Row { get; set; }

        int Column { get; set; }
    }
}
