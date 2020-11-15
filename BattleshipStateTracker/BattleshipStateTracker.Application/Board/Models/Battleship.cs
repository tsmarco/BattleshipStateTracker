using System.Collections.Generic;
using System.Drawing;

namespace BattleshipStateTracker.Application.Board.Models
{
    public class Battleship
    {
        public Point StartCoordinate { get; set; }
        public Point EndCoordinate { get; set; }
        public bool IsSunk { get; set; }

        public List<Point> Hits { get; set; }
    }

}
