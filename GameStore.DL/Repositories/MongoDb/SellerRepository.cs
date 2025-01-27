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


    public class SellerRepository : ISellerRepository
    {

        private IOptions<MongoDbConfiguration> _mongoConfig;
        private readonly IMongoCollection<Seller> _sellers;

        public SellerRepository(
                   IOptions<MongoDbConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;

            var client =
                new MongoClient(mongoConfig.Value.ConnectionString);

            var db =
                client.GetDatabase(mongoConfig.Value.DatabaseName);

            _sellers = db.GetCollection<Seller>("Sellers");

        }

        public List<Seller> GetAll()
        {
            return StaticData.StaticDb.SellersData;
        }

        public Seller? GetById(int id)
        {
            return StaticData.StaticDb.SellersData
               .FirstOrDefault(s => s.Id == id);
        }

        public void Add(Seller seller)
        {
            StaticData.StaticDb.SellersData.Add(seller);
        }

        public void Delete(int id)
        {
            var seller = GetById(id);

            if (seller != null)
            {
                StaticData.StaticDb.SellersData.Remove(seller);
            }
        }
    }
}

