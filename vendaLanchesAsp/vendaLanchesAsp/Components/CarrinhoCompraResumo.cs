﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vendaLanchesAsp.Models;
using vendaLanchesAsp.ViewModels;

namespace vendaLanchesAsp.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }
        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
           // var itens = new List<CarrinhoCompraItem>() { new CarrinhoCompraItem() };
            _carrinhoCompra.CarrinhoCompraItens = itens;
            var carrinhoView = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                TotalCarrinhoCompra = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoView);
        }
    }
}
