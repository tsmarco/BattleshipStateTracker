using System.Collections.Generic;

namespace BattleshipStateTracker.Application.Board.Models
{
    public class Board
    {
        public List<Panel> Panels { get; set; }

        public Board(int size)
        {
            Panels = new List<Panel>();
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Panels.Add(new Panel(i, j));
                }
            }
        }

    }
}
