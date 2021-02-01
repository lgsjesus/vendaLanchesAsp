﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Context;
using vendaLanchesAsp.Models;

namespace vendaLanchesAsp.Repositories
{
    public class CategoriaRepository : ICategorias
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
