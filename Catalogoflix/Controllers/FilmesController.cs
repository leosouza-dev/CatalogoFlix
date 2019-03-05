using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catalogoflix.Services;
using Catalogoflix.Models;
using Catalogoflix.Data;

namespace Catalogoflix.Controllers
{
    public class FilmesController : Controller
    {
        // *************** dependecia de FilmeService ***************
        private readonly FilmeService _filmeService;
        private readonly ApplicationDbContext _context;

        public FilmesController(FilmeService filmeService, ApplicationDbContext context)
        {
            _filmeService = filmeService;
            _context = context;
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

            //****
            var result = from obj in _context.InteresseFilme select obj;
            if (!result.Any(x => x.Titulo == filme.Titulo))
            {
                _filmeService.Inserir(filme);
                return RedirectToAction("Index");
            }

            _filmeService.Inserir(filme);
            var emails = result.Where(e => e.Titulo == filme.Titulo);
            TempData["NomeFilme"] = filme.Titulo.ToString();
            return RedirectToAction("Email");

        }

        public IActionResult Email()
        {
            var filme = TempData["NomeFilme"];
            var result = from obj in _context.InteresseFilme select obj;
            var emails = result.Where(e => e.Titulo == (string)filme);
            return View(emails);
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