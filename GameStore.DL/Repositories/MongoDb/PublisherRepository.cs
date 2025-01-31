using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DnsClient.Internal;
using GameStore.DL.Interfaces;
using GameStore.Models.Configurations;
using GameStore.Models.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace GameStore.DL.Repositories.MongoDb
{


    public class PublisherRepository : IPublisherRepository
    {

        private IOptions<MongoDbConfiguration> _mongoConfig;
        private readonly IMongoCollection<Publisher> _publishers;

        public PublisherRepository(
                   IOptions<MongoDbConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;

            var client =
                new MongoClient(mongoConfig.Value.ConnectionString);

            var db =
                client.GetDatabase(mongoConfig.Value.DatabaseName);

            _publishers = db.GetCollection<Publisher>("Publishers");

        }

        public List<Publisher> GetAll()
        {
            return StaticData.StaticDb.Publishers;
        }

        public Publisher? GetById(string id)
        {
            return StaticData.StaticDb.Publishers
               .FirstOrDefault(p => p.Id == id);
        }

        public Publisher Add(Publisher publisher)
        {
            StaticData.StaticDb.Publishers.Add(publisher);

            return publisher;
        }

        public Publisher Delete(string id)
        {
            var publisher = StaticData.StaticDb.Publishers.FirstOrDefault(publisher => publisher.Id == id);

            StaticData.StaticDb.Publishers.Remove(publisher);

            return publisher;
        }

        public Publisher Update(string id, Publisher publisher)
        {
            var result = StaticData.StaticDb.Publishers.FirstOrDefault(p => p.Id == publisher.Id);

            result.Name = publisher.Name;

            return result;
        }
    }
}

