using GameStore.Models.DTO;

namespace GameStore.Models.Responses
{
    public class GameFullDetailsResponse
    {
        public string Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
    }
}
