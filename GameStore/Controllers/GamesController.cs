using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using GameStore.BL.Interfaces;
using GameStore.Models.DTO;
using GameStore.Models.Requests;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gameService;
        private readonly IMapper _mapper;

        public GamesController(
            IGamesService gameService,
            IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _gameService.GetAll();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest($"Wrong ID:{id}");
            }

            var result = _gameService.GetById(id);

            if (result == null)
            {
                return NotFound($"Game with ID:{id} not found");
            }

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody]AddGameRequest game)
        {
            var gameDto = _mapper.Map<Game>(game);

            _gameService.Add(gameDto);

            return Ok();
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            //return _gameService.GetById(id);
        }
    }
}
