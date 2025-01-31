using Microsoft.AspNetCore.Mvc;
using GameStore.BL.Interfaces;
using GameStore.Models.DTO;
using GameStore.Models.Requests;
using MapsterMapper;
using GameStore.Models.Responses;
using ZstdSharp.Unsafe;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {


        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Publisher> GetAll()
        {
            return _publisherService.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public Publisher? GetById(string id)
        {
            return _publisherService.GetById(id);
        }

        [HttpPost("Add")]
        public void Add([FromBody] Publisher publisher)
        {
            _publisherService.Add(publisher);

        }

        [HttpDelete("Delete/{id}")]
        public void Delete(string id)
        {
            _publisherService.Delete(id);

            

        }

        [HttpPut("Update")]
        public void Update(string id, [FromBody] Publisher publisher)
        {

           _publisherService.Update(id, publisher);
            
        }

    }
}




