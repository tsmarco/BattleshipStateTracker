using System.Collections.Generic;
using System.Drawing;

namespace BattleshipStateTracker.Application.Board
{
    public interface IBoardService
    {
        Models.Board BoardAState { get; set; }
        Models.Board BoardBState { get; set; }

        bool AddBattleShip(Point startCoordinate, Point endCoordinate, string board);
        bool Attack(Point coordinate, string board);
        List<string> GetBoard(string board);
        bool Reset(int size = 10);
    }
}