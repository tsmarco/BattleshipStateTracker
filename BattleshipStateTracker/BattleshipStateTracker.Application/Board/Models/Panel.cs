using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BattleshipStateTracker.Application.Board.Models
{
    public class Panel
    {
        public OccupationType OccupationType { get; set; }
        public Point Coordinates { get; set; }

        public Panel(int row, int column)
        {
            Coordinates = new Point(row, column);
            OccupationType = OccupationType.Empty;
        }

        public string Status
        {
            get
            {
                return Enum.GetName(typeof(OccupationType), OccupationType); 
            }
        }

        public bool IsOccupied
        {
            get
            {
                return OccupationType == OccupationType.Occupied;
            }
        }

        public bool IsRandomAvailable
        {
            get
            {
                return (Coordinates.X % 2 == 0 && Coordinates.Y % 2 == 0)
                    || (Coordinates.X % 2 == 1 && Coordinates.Y % 2 == 1);
            }
        }

        
    }
}
