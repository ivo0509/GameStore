using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GameStore.DL.Interfaces;
using GameStore.Models.Configurations;
using GameStore.Models.DTO;

namespace GameStore.DL.Repositories.MongoDb
{
    internal class GamesMongoRepository : IGameRepository
    {
        private readonly IMongoCollection<Game> _gamesCollection;
        private readonly ILogger<GamesMongoRepository> _logger;

        public GamesMongoRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<GamesMongoRepository> logger)
        {
            _logger = logger;

            var client = 
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);
            _gamesCollection = database.GetCollection<Game>("GamesDb");
        }

        public List<Game> GetAll()
        {
            return _gamesCollection.Find(g => true)
                .ToList();
        }

        public Game? GetById(string id)
        {
            return _gamesCollection
                .Find(g => g.Id == id)
                .FirstOrDefault();
        }

        public void Add(Game? game)
        {
            if (game == null)
            {
                _logger.LogError("Game is null");
                return;
            }

            
            try
            {
                _gamesCollection.InsertOne(game);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add game");
            }
        }

        public void Update(Game game)
        {
            _gamesCollection.ReplaceOne(g => g.Id == game.Id, game);
        }
    }
}
