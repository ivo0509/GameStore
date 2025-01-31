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
    public class GamesController : ControllerBase
    {
       
      
         private readonly IGameService _gameService;

            public GamesController(IGameService gameService)
            {
               _gameService = gameService;
            }

            [HttpGet("GetAll")]
            public IEnumerable<Game> GetAll()
            {
            return _gameService.GetAllGames();
            }

            [HttpGet("GetById/{id}")]
            public Game? GetById(string id)
            {
                return _gameService.GetById(id);
            }

            [HttpPost("Add")]
            public void Add([FromBody] Game game)
            {
            _gameService.Add(game);
            }

            [HttpDelete("Delete/{id}")]
            public void Delete(string id)
            {
                _gameService.Delete(id);
            }

       [HttpPut("Update/{id}")]
        public void Update(string id, [FromBody]Game game)
        {
           
            _gameService.Update(id, game);
        }

    }





}




