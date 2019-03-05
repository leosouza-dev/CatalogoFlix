using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catalogoflix.Services;
using Catalogoflix.Models;

namespace Catalogoflix.Controllers
{
    public class FilmesController : Controller
    {
        // *************** dependecia de FilmeService ***************
        private readonly FilmeService _filmeService;

        public FilmesController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        // *************** 


        public IActionResult Index()
        {
            var lista = _filmeService.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }
            _filmeService.Inserir(filme);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            var obj = _filmeService.EncontrarPorId(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            _filmeService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var obj = _filmeService.EncontrarPorId(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit));
            }
            _filmeService.Update(filme);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            var obj = _filmeService.EncontrarPorId(id.Value);
            return View(obj);
        }
    }
}