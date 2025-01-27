using GameStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.Interfaces
{
    public interface ISellerService
    {
        List<Seller> GetAll();

        Seller? GetById(int id);

        void Add(Seller seller);

        void Delete(int id);

    }
}

