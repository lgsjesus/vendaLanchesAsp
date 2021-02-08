using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vendaLanchesAsp.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login","Account");
        }
    }
}
