using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Models;

namespace vendaLanchesAsp.Repositories
{
    public interface ICategorias
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
