using Microsoft.AspNetCore.Mvc;
using GameStore.BL.Interfaces;
using GameStore.Models.DTO;
using GameStore.Models.Requests;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _gameService;

        public BusinessController(IBusinessService gameService)

        {
            _gameService = gameService;
        }

        [HttpGet("GetAllDetailedGames")]
        public IActionResult GetAllDetailedGames()
        {
            var result =
                _gameService.GetAllGames();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost("Test")]
        public IActionResult Test([FromBody] TestRequest game)
        {
            
            return Ok();
        }
    }

    public class TestRequest
    {
        public int MagicNumber { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }
    }
}
