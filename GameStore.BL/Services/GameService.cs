using Microsoft.Extensions.Logging;
using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using System.Runtime.CompilerServices;
using GameStore.Models.Requests;
using DnsClient.Internal;

namespace GameStore.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPublisherRepository _publisherRepository;




        public GameService(IGameRepository gameRepository, IPublisherRepository publisherRepository)
        {
            _gameRepository = gameRepository;
            _publisherRepository = publisherRepository;

        }

        public List<Game> GetAllGames()
        {
            return _gameRepository.GetAllGames();
        }

        public Game? GetById(string id)
        {
            return _gameRepository.GetById(id);
        }

        public Game Add(Game game)
        {
          return _gameRepository.Add(game);
        }
        public Game Delete(string id)
        {

           return _gameRepository.Delete(id);

        }

        public Game Update(string id, Game game)
        {
            return _gameRepository.Update(id, game);
        }
    }


}

