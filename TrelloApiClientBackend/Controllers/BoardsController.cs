using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BoardsController(ITrelloApiBroker trelloApiBroker,IMapper mapper)
        {
            _trelloApiBroker = trelloApiBroker;
            _mapper = mapper;
        }

        [HttpGet("{boardId}")]
        public async Task<ActionResult<Result<BoardResponseDto>>> GetBoard(string boardId)
        {
            var getBoard =
                await _trelloApiBroker.Get<TrelloBoardResponseExternal>(TrelloApiRoutes.Boards.Board(boardId));
            if (getBoard.IsSuccess)
            {
                return Ok(_mapper.Map<BoardResponseDto>(getBoard.Value));
            }

            return BadRequest(getBoard.Error);
        }
    }
}