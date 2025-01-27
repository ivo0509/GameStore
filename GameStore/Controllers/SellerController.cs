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
    public class SellerController : ControllerBase
    {
       
      
         private readonly ISellerService _sellerService;

            public SellerController(ISellerService sellerService)
            {
               _sellerService = sellerService;
            }

            [HttpGet("GetAll")]
            public IEnumerable<Seller> GetAll()
            {
                return _sellerService.GetAll();
            }

            [HttpGet("GetById")]
            public Seller? GetById(int id)
            {
                return _sellerService.GetById(id);
            }

            [HttpPost("Add")]
            public void Add([FromBody] Seller seller)
            {
                _sellerService.Add(seller);
            }

            [HttpDelete("Delete")]
            public void Delete(int id)
            {
                _sellerService.Delete(id);
            }

        }





}




