using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Repositories;
using vendaLanchesAsp.ViewModels;

namespace vendaLanchesAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILanches _lanche;

        public HomeController(ILogger<HomeController> logger, ILanches lanches)
        {
            _logger = logger;
            _lanche = lanches;
        }

        public IActionResult Index()
        {
            var preferido = _lanche.LanchesPreferidos;
            var lanchePreferido = new HomeViewModel
            {
                LanchesPreferidos = preferido
            };
            return View(lanchePreferido);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
