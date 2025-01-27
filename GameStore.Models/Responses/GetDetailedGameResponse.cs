using GameStore.Models.DTO;

namespace GameStore.Models.Responses
{
    public class GetDetailedGameResponse
    {
        public Seller Seller { get; set; }
        public List<Game> Games { get; set; }

       
    }
}
