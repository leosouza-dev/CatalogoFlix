using Catalogoflix.Data;
using Catalogoflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogoflix.Services
{
    public class InteresseFilmeService
    {
        // *************** dependecia de DbContext ***************
        private readonly ApplicationDbContext _context;
        public InteresseFilmeService(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***************  

        public List<InteresseFilme> Listar()
        {
            return _context.InteresseFilme.ToList();
        }

        public void Inserir(InteresseFilme interesseFilme)
        {
            _context.Add(interesseFilme);
            _context.SaveChanges();
        }
    }
}
