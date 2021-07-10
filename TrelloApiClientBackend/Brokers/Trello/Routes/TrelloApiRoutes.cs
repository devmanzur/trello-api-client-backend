namespace TrelloApiClientBackend.Brokers.Trello.Routes
{
    public static class TrelloApiRoutes
    {
        public static class Boards
        {
            public static string Board(string boardId) => $"1/boards/{boardId}";
        }
    }
}