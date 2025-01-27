namespace GameStore.Models.Requests
{
    public class AddGameRequest
    {
        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int SellerId { get; set; }

        public DateTime AfterDate { get; set; }
    }
}
