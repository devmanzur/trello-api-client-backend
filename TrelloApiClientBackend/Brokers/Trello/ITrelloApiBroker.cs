using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace TrelloApiClientBackend.Brokers
{
    public interface ITrelloApiBroker
    {
        Task<Result<TResponse>> Get<TResponse>(string path);
    }
}