using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using TrelloApiClientBackend.Brokers.Trello;
using TrelloApiClientBackend.Brokers.Trello.Responses;
using TrelloApiClientBackend.Brokers.Trello.Routes;
using TrelloApiClientBackend.Contracts.Responses;

namespace TrelloApiClientBackend.Controllers
{
    public class BoardsController : ApplicationBaseController
    {
        private readonly ITrelloApiBroker _trelloApiBroker;

        public BoardsController(ITrelloApiBroker trelloApiBroker)
        {
            _trelloApiBroker = trelloApiBroker;
        }

        [HttpGet("{boardId}")]
        public async Task<ActionResult<Result<BoardResponseDto>>> GetBoard(string boardId)
        {
            var getBoard =
                await _trelloApiBroker.Get<TrelloBoardResponseExternal>(TrelloApiRoutes.Boards.Board(boardId));
            if (getBoard.IsSuccess)
            {
                return Ok(getBoard.Value);
            }

            return BadRequest(getBoard.Error);
        }
    }
}