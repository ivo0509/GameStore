using GameStore.Models.Responses;

namespace GameStore.BL.Interfaces
{
    public interface IBusinessService
    {
        List<GameFullDetailsResponse> GetAllGames();
    }
}
