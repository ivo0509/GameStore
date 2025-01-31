using GameStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.Interfaces
{
    public interface IPublisherService
    {
        List<Publisher> GetAll();

        Publisher? GetById(string id);

        void Add(Publisher publisher);

        void Delete(string id);

        void Update(string id, Publisher publisher);

    }
}

