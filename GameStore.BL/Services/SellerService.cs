using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static GameStore.BL.Services.SellerService;

namespace GameStore.BL.Services
{



    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public void Add(Seller seller)
        {
            _sellerRepository.Add(seller);
        }

        public void Delete(int id)
        {
            _sellerRepository.Delete(id);
        }

        public List<Seller> GetAll()
        {
            return _sellerRepository.GetAll();
        }

        public Seller? GetById(int id)
        {
            if (id <= 0) return null;

            return _sellerRepository.GetById(id);
        }

    
    }
}

