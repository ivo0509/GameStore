using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;

namespace GameStore.DL.Repositories.MongoDb
{
    internal class PlayerRepository : IPlayerRepository
    {
        public List<Player> GetAll()
        {
            throw new NotImplementedException();
        }

        public Player? GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
