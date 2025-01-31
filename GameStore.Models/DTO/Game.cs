namespace GameStore.Models.DTO
{
    public class Game
    {

        public string Id { get; set; }
        public int PublisherId { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }

        public List<string> Publishers { get; set; }


    
    }
}
