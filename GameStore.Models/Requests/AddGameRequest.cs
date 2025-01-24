namespace GameStore.Models.Requests
{
    public class AddGameRequest
    {
        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }
    }
}
