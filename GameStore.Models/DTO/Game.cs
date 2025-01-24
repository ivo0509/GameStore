namespace GameStore.Models.DTO
{
    public class Game
    {
        public string Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public List<string> Players { get; set; }
    }
}
