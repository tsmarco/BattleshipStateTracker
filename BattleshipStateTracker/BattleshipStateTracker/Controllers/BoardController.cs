using BattleshipStateTracker.Application.Board;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BattleshipStateTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;


        private readonly ILogger<BoardController> _logger;

        public BoardController(ILogger<BoardController> logger, IBoardService boardService)
        {
            _boardService = boardService;
            _logger = logger;
        }

        // reset board 

        [HttpGet("Reset")]
        public IActionResult Reset(int size = 10)
        {
            try
            {
                bool response = _boardService.Reset(size) ;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        

        [HttpGet("{board}")]
        public IActionResult Index(string board)
        {
            try
            {
                var response = _boardService.GetBoard(board);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // place 
        [HttpPut("{board}/BattleShip")]
        public IActionResult AddBattleShip(int startRow, int endRow, int startCol, int endCol, string board)
        {
            try
            {
                bool response = _boardService.AddBattleShip(
                    new System.Drawing.Point(startRow, startCol),
                    new System.Drawing.Point(endRow, endCol),
                    board);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //attack
        [HttpPut("{board}/BattleShip/Attack")]
        public IActionResult Attack(int row, int col, string board)
        {
            try
            {
                bool response = _boardService.Attack(new System.Drawing.Point(row, col), board);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
