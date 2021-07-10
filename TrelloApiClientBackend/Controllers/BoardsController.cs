using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using TrelloApiClientBackend.Brokers;
using TrelloApiClientBackend.Brokers.Reesponses;

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
        public async Task<ActionResult<Result<TrelloBoardResponseExternal>>> GetBoard(string boardId)
        {
            var getBoard = await _trelloApiBroker.Get<TrelloBoardResponseExternal>("");
            if (getBoard.IsSuccess)
            {
                return Ok(getBoard.Value);
            }

            return BadRequest(getBoard.Error);
        }
    }
}