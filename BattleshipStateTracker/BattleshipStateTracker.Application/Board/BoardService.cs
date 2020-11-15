using BattleshipStateTracker.Application.Board.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipStateTracker.Application.Board
{
    public class BoardService : IBoardService
    {
        public Models.Board BoardAState { get; set; }
        public Models.Board BoardBState { get; set; }
        public BoardService()
        {
            Reset();
        }

        /// <summary>
        /// Resets all boards
        /// </summary>
        /// <param name="size">size</param>
        public bool Reset(int size = 10)
        {
            BoardAState = new Models.Board(size);
            BoardAState = new Models.Board(size);
            return true;
        }

        /// <summary>
        /// Adds a battleship to a board
        /// </summary>
        /// <param name="startCoordinate">startCoordinate</param>
        /// <param name="endCoordinate">endCoordinate</param>
        /// <param name="board">board</param>
        public bool AddBattleShip(Point startCoordinate, Point endCoordinate, string board)
        {
            switch (board)
            {
                case ("A"):
                    BoardAState.Panels.Where(x => x.Coordinates.X >= startCoordinate.X
                                     && x.Coordinates.Y >= startCoordinate.Y
                                     && x.Coordinates.X <= endCoordinate.X
                                     && x.Coordinates.Y <= endCoordinate.Y)
                        .ToList().ForEach(panel => panel.OccupationType = Models.OccupationType.Occupied);
                    return true;
                case ("B"):
                    BoardBState.Panels.Where(x => x.Coordinates.X >= startCoordinate.X
                                     && x.Coordinates.Y >= startCoordinate.Y
                                     && x.Coordinates.X <= endCoordinate.X
                                     && x.Coordinates.Y <= endCoordinate.Y)
                        .ToList().ForEach(panel => panel.OccupationType = Models.OccupationType.Occupied);
                    return true;
                default:
                    throw new ArgumentException($"The board selected does not exist.");
            }

        }

        /// <summary>
        /// Attacks a coordinate on a board
        /// </summary>
        /// <param name="coordinate">coordinate</param>
        /// <param name="board">board</param>
        public bool Attack(Point coordinate, string board)
        {
            switch (board)
            {
                case ("A"):
                    BoardAState.Panels.Where(x => x.Coordinates.X == coordinate.X
                                     && x.Coordinates.Y == coordinate.Y)
                        .ToList().ForEach(panel =>  AttackPanel(panel));
                    return true;
                case ("B"):
                    BoardBState.Panels.Where(x => x.Coordinates.X == coordinate.X
                                     && x.Coordinates.Y == coordinate.Y)
                        .ToList().ForEach(panel => AttackPanel(panel));
                    return true;
                default:
                    throw new ArgumentException($"The board selected does not exist.");
            }
        }

        private static void AttackPanel(Panel panel)
        {
            if (panel.OccupationType == Models.OccupationType.Occupied)
            {
                panel.OccupationType = Models.OccupationType.Hit;
            }
            else
            {
                panel.OccupationType = Models.OccupationType.Miss;
            }
        }

        /// <summary>
        /// Retrieves all coordinates on a board
        /// </summary>
        /// <param name="board">board</param>
        public List<string> GetBoard(string board)
        {
            switch (board)
            {
                case ("A"):
                    var panelsA = BoardAState.Panels
                        .Select(panel => $"{panel.Coordinates.X}:{panel.Coordinates.Y}:{panel.OccupationType}");
                    return panelsA.ToList();
                case ("B"):
                    var panelsB = BoardBState.Panels
                        .Select(panel => $"{panel.Coordinates.X}:{panel.Coordinates.Y}:{panel.OccupationType}");
                    return panelsB.ToList();
                default:
                    throw new ArgumentException($"The board selected does not exist.");
            }

        }

    }
}
