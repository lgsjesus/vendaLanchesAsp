using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Context;
using vendaLanchesAsp.Models;

namespace vendaLanchesAsp.Repositories
{
    public class LancheRepository : ILanches
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(c => c.IsLanchePreferido).Include(c => c.Categoria);

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c=>c.Categoria);

        public Lanche LanchesById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(c => c.LancheId == lancheId);

        }
    }
}
