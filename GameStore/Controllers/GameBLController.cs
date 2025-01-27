using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using GameStore.BL.Interfaces;
using GameStore.Models.DTO;
using GameStore.Models.Requests;
using GameStore.Models.Views;
using GameStore.Models.Responses;
using GameStore.BL.Services;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameBLController : ControllerBase
    {
        private readonly IGameBlService _gameBlService;
        public GameBLController(
            IGameBlService gameBlService)
        {
            _gameBlService = gameBlService;
        }

        [HttpPost("GetAllGamesBySeller")]
        public GetDetailedGameResponse?
            GetAllGamesBySeller([FromBody]
                AddGameRequest request)
        {
            return _gameBlService
                .GetAllGamesBySellerAfterDate(request);
        }



    }
}
