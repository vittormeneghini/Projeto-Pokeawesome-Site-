using Pokemon.Models.Entities;
using Pokemon.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon.Repository.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public void AdicionarItemPlayer(long codigoPlayer)
        {
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 1, 101, 2120, 1, new byte[0]));
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 2, 102, 2580, 1, new byte[0]));
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 3, 103, 1987, 1, new byte[0]));
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 4, 104, 2550, 1, new byte[0]));
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 5, 105, 1988, 1, new byte[0]));
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 6, 106, 2382, 1, new byte[0]));
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 7, 107, 2395, 1, new byte[0]));
            _context.PlayerItems.Add(new PlayerItems(codigoPlayer, 9, 108, 7385, 1, new byte[0]));

            _context.SaveChanges();
        }

        public long ListarQtdOnline()
        {
            return ListByParameter(p => p.Online == true).ToList().Count();                
        }
    }
}
