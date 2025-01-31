using GameStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DL.Interfaces
{
    public interface IPublisherRepository
    {
        List<Publisher> GetAll();

        Publisher? GetById(string id);

        Publisher Add(Publisher publisher);

        Publisher Delete (string id);

        Publisher Update (string id, Publisher publisher);

    }
}
