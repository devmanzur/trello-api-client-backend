using System.Net.Http;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;
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
                var output = JsonConvert.DeserializeObject<TResponse>(responseBody);
                return Result.Success(output);
            }

            return Result.Failure<TResponse>(responseBody);
        }
    }
}