using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GameStore.DL.Interfaces;
using GameStore.Models.Configurations;
using GameStore.Models.DTO;
using GameStore.DL.Repositories;

namespace GameStore.DL.Repositories.MongoDb
{
    public class GameRepository : IGameRepository
    {
        private IOptions<MongoDbConfiguration> _mongoConfig;
        private readonly IMongoCollection<Game> _games;

        public GameRepository(
            IOptions<MongoDbConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;

            var client =
                new MongoClient(mongoConfig.Value.ConnectionString);

            var db =
                client.GetDatabase(mongoConfig.Value.DatabaseName);

            _games = db.GetCollection<Game>("Games");
        }

        public List<Game> GetAllGamesBySeller(int sellerId)
        {
           return StaticData.StaticDb.GameData.Where(g => g.SellerId == sellerId).ToList();
        }
    }
}

