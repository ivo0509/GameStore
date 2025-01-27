using GameStore.Models.DTO;
using GameStore.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DL.Interfaces
{
    public interface IGameRepository
    {
        List<Game> GetAllGamesBySeller(int sellerId);
    }
}
