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

        public List<Game> GetAllGames()
        {
            return StaticData.StaticDb.Games;
        }


        public Game? GetById(string id)
        {
            return StaticData.StaticDb.Games
                .FirstOrDefault(g => g.Id == id);
        }

        public Game Add(Game game)
        {
            StaticData.StaticDb.Games.Add(game);

            return game;
        }

        public Game Delete(string id)
        {
            var game = StaticData.StaticDb.Games.FirstOrDefault(game => game.Id == id);

            StaticData.StaticDb.Games.Remove(game);

            return game;
        }

        public Game Update(string id, Game game)
        {
            var result = StaticData.StaticDb.Games.FirstOrDefault(g => g.Id == game.Id);

            result.Name = game.Name;

            return result;
        }

    }
}

