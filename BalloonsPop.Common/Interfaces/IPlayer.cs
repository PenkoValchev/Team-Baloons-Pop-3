namespace BalloonsPop.Common.Interfaces
{
    using System;

    public interface IPlayer : IComparable<IPlayer>
    {
        string Name { get; }

        int Score { get; set; }
    }
}