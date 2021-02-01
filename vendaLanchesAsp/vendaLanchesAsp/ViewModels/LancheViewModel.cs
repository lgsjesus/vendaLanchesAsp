using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Models;
using vendaLanchesAsp.Repositories;

namespace vendaLanchesAsp.ViewModels
{
    public class LancheViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string Categoria { get; set; }
    }
}
