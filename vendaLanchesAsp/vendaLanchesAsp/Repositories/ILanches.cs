using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Models;

namespace vendaLanchesAsp.Repositories
{
    public interface ILanches
    {
        Lanche LanchesById(int lancheId);
        IEnumerable<Lanche> LanchesPreferidos { get; }
        IEnumerable<Lanche> Lanches { get;  }
    }
}
