using Xunit;
using Shouldly;
using BattleshipStateTracker.Application.Board;
using System.Linq;

namespace BattleshipStateTracker.Search.Tests
{

    public class BoardServiceTests
    {
        private BoardService subject;

        public BoardServiceTests()
        {
            //Arrange
            subject = new BoardService();

        }

        [Fact()]
        public void ResetTest()
        {
            // Arrange
            var expected = true;
            subject.BoardAState = null;

            // Act
            var output = subject.Reset();

            // Assert
            output.ShouldBe(expected);
            subject.BoardAState.Panels.Count.ShouldBe(100);
        }


        [Fact()]
        public void AddBattleShipTest()
        {
            // Arrange
            var expected = true;

            System.Drawing.Point startCoordinate = new System.Drawing.Point(1,1);
            System.Drawing.Point endCoordinate = new System.Drawing.Point(1, 2);
            string board = "A";
            // Act
            var output = subject.AddBattleShip(startCoordinate,endCoordinate, board);

            // Assert
            output.ShouldBe(expected);
            subject.BoardAState.Panels.Where(panel => panel.IsOccupied).Count().ShouldBe(2);

        }
        [Fact()]
        public void AttackTest()
        {
            // Arrange
            System.Drawing.Point coordinate = new System.Drawing.Point(1, 1);
            string board = "A";
            var expected = true;

            // Act
            var output = subject.Attack(coordinate, board);

            // Assert
            output.ShouldBe(expected);
            subject.BoardAState.Panels.Where(panel => panel.OccupationType == Application.Board.Models.OccupationType.Hit).Count().ShouldBe(0);
            subject.BoardAState.Panels.Where(panel => panel.OccupationType == Application.Board.Models.OccupationType.Miss).Count().ShouldBe(1);

        }

        [Fact()]
        public void AttackShouldHitOccupiedPanelsTest()
        {
            // Arrange
            System.Drawing.Point coordinate = new System.Drawing.Point(1, 1);
            string board = "A";
            var expected = true;
            subject.BoardAState.Panels.Where(panel => 
            panel.Coordinates.X == 1 && panel.Coordinates.Y == 1)
                .Single().OccupationType = Application.Board.Models.OccupationType.Occupied;

            // Act
            var output = subject.Attack(coordinate,board);

            // Assert
            output.ShouldBe(expected);
            subject.BoardAState.Panels.Where(panel => panel.OccupationType == Application.Board.Models.OccupationType.Hit).Count().ShouldBe(1);
            subject.BoardAState.Panels.Where(panel => panel.OccupationType == Application.Board.Models.OccupationType.Miss).Count().ShouldBe(0);

        }

        [Fact()]
        public void GetBoardTest()
        {
            // Arrange
            string board = "A";

            // Act
            var output = subject.GetBoard(board);

            // Assert
            output.Count.ShouldBe(100);
        }


    }
}