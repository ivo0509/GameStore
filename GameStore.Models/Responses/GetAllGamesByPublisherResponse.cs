using GameStore.Models.DTO;

namespace GameStore.Models.Responses
{
    public class GetAllGamesByPublisherResponse
    {
        public Publisher Publisher { get; set; }
        public List<Game> Games { get; set; }

       
    }
}
