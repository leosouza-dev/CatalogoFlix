using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogoflix.Models;
using Catalogoflix.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalogoflix.Controllers
{
    public class InteresseFilmesController : Controller
    {

        // *************** dependecia de FilmeService ***************
        private readonly InteresseFilmeService _interesseFilmeService;

        public InteresseFilmesController(InteresseFilmeService interesseFilmeService)
        {
            _interesseFilmeService = interesseFilmeService;
        }
        // *************** 


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InteresseFilme intersseFilme)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }
            _interesseFilmeService.Inserir(intersseFilme);
            return RedirectToAction("Index", "Filmes");
        }
    }
}