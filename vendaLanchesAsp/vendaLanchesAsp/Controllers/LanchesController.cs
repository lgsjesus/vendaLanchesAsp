using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Models;
using vendaLanchesAsp.Repositories;
using vendaLanchesAsp.ViewModels;

namespace vendaLanchesAsp.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILanches _lanche;

        public LanchesController(ILanches lanche)
        {
            _lanche = lanche;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(string categoria)
        {
            ViewBag.Lanche = "Lanches";
            ViewData["Categorias"] = "Categoria";
            IEnumerable<Lanche> _listaLanches =null;
            string _categoria = "Todas as Categorias";
            if (string.IsNullOrEmpty(categoria))
            {
                _listaLanches = _lanche.Lanches.OrderBy(l => l.Nome);

            }else if (categoria.ToUpper().Equals("NATURAL"))
            {
                _listaLanches = _lanche.Lanches.Where(l=> l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);
                _categoria = "Natural";
            }
            else if (categoria.ToUpper().Equals("NORMAL"))
            {
                _listaLanches = _lanche.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
                _categoria = "Normal";
            }
            //return View(_lanche.Lanches);
            LancheViewModel model = new LancheViewModel();
            model.Lanches = _listaLanches;
            model.Categoria = _categoria;
            return View(model);
        }

    }
}
