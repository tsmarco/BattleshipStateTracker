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

        /// <summary>
        /// Resets all boards
        /// </summary>
        /// <param name="size">Size of board</param>
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


        /// <summary>
        /// Retrieves a lists of board 
        /// </summary>
        /// <param name="board">Board Index(A or B)</param>
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

        /// <summary>
        /// Adds a battleship to a board
        /// </summary>
        /// <param name="startRow">Start Row</param>
        /// <param name="endRow">End Row</param>
        /// <param name="startCol">Start column</param>
        /// <param name="endCol">End column</param>
        /// <param name="board">Board Index(A or B)</param>
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

        /// <summary>
        /// Attacks a coordinate on a board
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <param name="board">Board Index(A or B)</param>
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
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
