﻿using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<Lanche> _listaLanches = null;
            string _categoria = "Todas as Categorias";
            if (string.IsNullOrEmpty(categoria))
            {
                _listaLanches = _lanche.Lanches.OrderBy(v=>v.Nome);

            }
            else if (categoria.ToUpper().Equals("NATURAL"))
            {
                _listaLanches = _lanche.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);
                _categoria = "Natural";
            }
            else if (categoria.ToUpper().Equals("NORMAL"))
            {
                _listaLanches =  _lanche.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
                _categoria = "Normal";
            }
            //return View(_lanche.Lanches);
            LancheViewModel model = new LancheViewModel();
            model.Lanches = _lanche.Lanches;
            model.Categoria = "Categoria Atual";
            model.Lanches = (IEnumerable<Models.Lanche>)_listaLanches;
            model.Categoria = _categoria;
            return View(model);
        }
        public IActionResult Details(int lancheId)
        {

            var lanche = _lanche.Lanches.FirstOrDefault();
            if (lanche != null)
            {
                return View(lanche);
            }
            else{
                return View("Error");
            }
        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Lanche> lanches;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                lanches = _lanche.Lanches.OrderBy(p => p.LancheId);
            }
            else
            {
                lanches = _lanche.Lanches.Where(p => p.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Lanche/List.cshtml", new LancheViewModel { Lanches = lanches, Categoria = "Todos os lanches" });
        }
    }
}
