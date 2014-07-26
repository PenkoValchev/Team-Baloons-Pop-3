namespace BaloonsUnitTest
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BalloonBoardTest
    {
        [TestMethod]
        public void CheckForNullValuesInBalloonBoard()
        { 
            BalloonBoard board = BalloonBoard.Instance;

            CollectionAssert.AllItemsAreNotNull(board.Field);
        }

        [TestMethod]
        public void IsBoardConentDifferentAfterRepopulate()
        {
            BalloonBoard board = BalloonBoard.Instance;
            IPlayGroundItem[,] field = (IPlayGroundItem[,])board.Field.Clone();

            board.RePopulate();

            int differenceCount = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (((IBalloon)field[row, col]).Type != ((IBalloon)board.Field[row, col]).Type)
                    {
                        differenceCount++;
                    }
                }
            }

            bool areNotEqual = false;
            int totalItems = board.Height * board.Width;
            if (differenceCount > totalItems / 2)
            {
                areNotEqual = true;
            }

            bool expected = false;

            Assert.AreNotEqual(expected, areNotEqual);
        }
    }
}