using AutoMapper;
using TrelloApiClientBackend.Brokers.Trello.Responses;
using TrelloApiClientBackend.Contracts.Responses;

namespace TrelloApiClientBackend.DtoMappings
{
    public class BoardResponseDtoMapper : Profile
    {
        public BoardResponseDtoMapper()
        {
            CreateMap<TrelloBoardResponseExternal, BoardResponseDto>()
                .ForMember(dto => dto.Description,
                    cfg =>
                        cfg.MapFrom(ext => ext.Desc));
        }
    }
}