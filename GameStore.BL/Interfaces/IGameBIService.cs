
using GameStore.Models.Requests;
using GameStore.Models.Responses;
using GameStore.Models.Views;

namespace GameStore.BL.Interfaces
{
    public interface IGameBlService
    {
        GetDetailedGameResponse?   GetAllGamesBySellerAfterDate(
                AddGameRequest request);

        int GetAllGamesCount(int inputCount, int sellerId);
    }
}
