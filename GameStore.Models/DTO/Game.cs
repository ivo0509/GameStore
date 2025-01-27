namespace GameStore.Models.DTO
{
    public class Game
    {

        public string Id { get; set; }
        public int SellerId { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }


        public List<string> Sellers { get; set; }
    }
}
