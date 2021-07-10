using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace TrelloApiClientBackend.Brokers.Trello
{
    public interface ITrelloApiBroker
    {
        Task<Result<TResponse>> Get<TResponse>(string path);
    }
}