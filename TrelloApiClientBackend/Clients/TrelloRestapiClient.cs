using System.Net.Http;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TrelloApiClientBackend.Brokers.Trello;

namespace TrelloApiClientBackend.Clients
{
    public class TrelloRestapiClient : ITrelloApiBroker
    {
        private readonly HttpClient _httpClient;

        public TrelloRestapiClient(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration.GetValue<string>("Trello:ApiKey");
            _userAuthToken = configuration.GetValue<string>("Trello:UserAuthToken");
        }
        
        private readonly string _apiKey;
        private readonly string _userAuthToken;
        private string SetupUrlAuthorization(string path) => $"{path}?key={_apiKey}&token={_userAuthToken}";


        public async Task<Result<TResponse>> Get<TResponse>(string path)
        {
            var response = await _httpClient.GetAsync(SetupUrlAuthorization(path));
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