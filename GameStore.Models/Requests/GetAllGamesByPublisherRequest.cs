namespace GameStore.Models.Requests
{
    public class GetAllGamesByPublisherRequest
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int PublisherId { get; set; }

        public DateTime AfterDate { get; set; }
    }
}
