using GameStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DL.Interfaces
{
    public interface IGameRepository
    {
        List<Game> GetAllGames();

        Game? GetById(string id);

        Game Add(Game game);

        Game Delete(string id);

        Game Update(string id, Game game);

    }
}
