using Microsoft.Extensions.Logging;
using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using System.Runtime.CompilerServices;
using GameStore.Models.Requests;
using DnsClient.Internal;
using GameStore.Models.Views;

namespace GameStore.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ISellerRepository _sellerRepository;




        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
          

        }

        public List<Game> GetAllGamesBySeller(int sellerId)
        {
            return _gameRepository.GetAllGamesBySeller(sellerId);
        }
    }
}

