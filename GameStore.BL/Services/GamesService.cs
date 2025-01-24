using Microsoft.Extensions.Logging;
using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using System.Runtime.CompilerServices;

namespace GameStore.BL.Services
{
    internal class GamesService : IGamesService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ILogger<GamesService> _logger;

        public GamesService(
            IGameRepository gameRepository,
            ILogger<GamesService> logger,
            IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _logger = logger;
            _playerRepository = playerRepository;
        }

        public void Add(Game game)
        {
            if (game == null)
            {
                _logger.LogError("Game is null");
                return;
            }

            game.Id = Guid.NewGuid().ToString();

            _gameRepository.Add(game);

        }

        public void AddPlayerToGame(string gameId, string playerId)
        {
            if (string.IsNullOrEmpty(gameId) || string.IsNullOrEmpty(playerId))
            {
                _logger.LogError("GameId or Player is null");
                return;
            }

            if (Guid.TryParse(gameId, out _) || Guid.TryParse(playerId, out _))
            {
                _logger.LogError("GameId or Player is not valid");
                return;
            }

            var game = _gameRepository.GetById(gameId);

            if (game == null)
            {
                _logger.LogError("Game not found");
                return;
            }

            var player = _playerRepository.GetById(playerId);

            if (player == null)
            {
                _logger.LogError("Player not found");
                return;
            }

            if (game.Players == null)
            {
                game.Players = new List<string>();
            }

            game.Players.Add(playerId);

            _gameRepository.Update(game);
        }

        public List<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        public Game? GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _)) return null;

            return _gameRepository.GetById(id);
        }


    }
}
