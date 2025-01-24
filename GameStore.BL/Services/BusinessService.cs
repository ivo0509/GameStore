using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using GameStore.Models.Responses;

namespace GameStore.BL.Services
{
    internal class BusinessService : IBusinessService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;

        public BusinessService(
            IGameRepository gameRepository,
            IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }

        public List<GameFullDetailsResponse> GetAllGames()
        {
            var result = new List<GameFullDetailsResponse>();

            var games = _gameRepository.GetAll() ?? new List<Game>();

            foreach (var game in games)
            {
                var detailedGame = new GameFullDetailsResponse()
                {
                    Id = game.Id,
                    Title = game.Title,
                    Year = game.Year
                };

                if (game.Players != null)
                {
                    foreach (var playerId in game.Players)
                    {
                        var player = _playerRepository.GetById(playerId);
                        if (player == null) continue;
                        detailedGame.Players.Add(player);
                    }
                }
           
                result.Add(detailedGame);
            }

            return result;
        }
    }
}
