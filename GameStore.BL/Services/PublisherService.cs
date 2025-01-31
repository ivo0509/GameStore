using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static GameStore.BL.Services.PublisherService;

namespace GameStore.BL.Services
{



    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void Add(Publisher publisher)
        {
            _publisherRepository.Add(publisher);
        }

        public void Delete(string id)
        {
            _publisherRepository.Delete(id);
        }

        public List<Publisher> GetAll()
        {
            return _publisherRepository.GetAll();
        }

        public Publisher? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return _publisherRepository.GetById(id);
        }

        public void Update(string id, Publisher publisher)
        {
            _publisherRepository.Update(id, publisher);
        }
    
    }
}

