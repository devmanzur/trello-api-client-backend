using System.Net.Http;

namespace TrelloApiClientBackend.Clients
{
    public class TrelloRestapiClient
    {
        private readonly HttpClient _httpClient;

        public TrelloRestapiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}