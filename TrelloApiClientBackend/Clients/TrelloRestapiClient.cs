using System.Net.Http;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using TrelloApiClientBackend.Brokers.Trello;

namespace TrelloApiClientBackend.Clients
{
    public class TrelloRestapiClient : ITrelloApiBroker
    {
        private readonly HttpClient _httpClient;

        public TrelloRestapiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<TResponse>> Get<TResponse>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            var responseBody = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                
            }

            return Result.Failure<TResponse>(responseBody);
        }
    }
}