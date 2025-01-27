using GameStore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Models.Views
{
    public class GameView
    {
        public string GameId { get; set; }

        public string GameTitle { get; set; } = string.Empty;

        public DateTime GameReleaseDate{ get; set; }

        public IEnumerable<Seller> Sellers { get; set; } = [];
    }
}
