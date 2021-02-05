using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Repositories;

namespace vendaLanchesAsp.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategorias _categoriaRepository;

        public CategoriaMenu(ICategorias categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(p => p.CategoriaNome);
            return View(categorias);
        }
    }
}
