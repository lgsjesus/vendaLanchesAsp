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
    public class CarrinhoCompraController : Controller
    {
        private readonly CarrinhoCompra _carrinhoCompra;
        private readonly ILanches _lanchesRepository;

        public CarrinhoCompraController(CarrinhoCompra carrinhoCompra, ILanches lanchesRepository)
        {
            _carrinhoCompra = carrinhoCompra;
            _lanchesRepository = lanchesRepository;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;
            var carrinhoCompraView = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                TotalCarrinhoCompra = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraView);
        }
        public RedirectToActionResult AdicionarItemAoCarrinho(int lancheID)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.Where(c => c.LancheId == lancheID).FirstOrDefault();
            if (lancheSelecionado != null) _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado, 1);

            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoverItemDoCarrinho(int lancheID)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.
                FirstOrDefault(c => c.LancheId == lancheID);
            if (lancheSelecionado != null) _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);

            return RedirectToAction("Index");
        }
    }
}
