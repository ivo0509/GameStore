using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.Views;
using GameStore.Models.DTO;
using GameStore.Models.Requests;
using GameStore.Models.Responses;
using static System.Reflection.Metadata.BlobBuilder;

namespace GameStore.BL.Services
{


    public class GameBlService : IGameBlService
    {
        private readonly IGameService _gameService;
        private readonly ISellerService _sellerService;
       
     

        public GameBlService(
            ISellerService sellerService,
            IGameService gameService)
        {
            _sellerService = sellerService;
            _gameService = gameService;
            
        }

        public GetDetailedGameResponse? GetAllGamesBySellerAfterDate(AddGameRequest request)
        {
            var games = _gameService
               .GetAllGamesBySeller(request.SellerId);

            var seller = _sellerService
                .GetById(request.SellerId);

            if (seller == null) return null;

            var result = new GetDetailedGameResponse
            {
                Seller = seller, 
                Games = games
                    .Where(g =>
                        g.ReleaseDate >= request.AfterDate)
                    .ToList()
            };

            return result;
        }

        public int GetAllGamesCount(int inputCount, int sellerId)
        {
            if (inputCount <= 0) return 0;

            var result = _gameService.GetAllGamesBySeller(sellerId);

            return result.Count + inputCount;
        }
    }
    }
