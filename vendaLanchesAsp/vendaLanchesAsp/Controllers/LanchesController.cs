using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult List()
        {
            ViewBag.Lanche = "Lanches";
            ViewData["Categorias"] = "Categoria";

            //return View(_lanche.Lanches);
            LancheViewModel model = new LancheViewModel();
            model.Lanches = _lanche.Lanches;
            model.Categoria = "Categoria Atual";
            return View(model);
        }

    }
}
