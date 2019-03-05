using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogoflix.Data;
using Catalogoflix.Models;

namespace Catalogoflix.Services
{
    public class FilmeService
    {
        // *************** dependecia de DbContext ***************
        private readonly ApplicationDbContext _context;
        public FilmeService(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***************  

        //metodo findall para retornar uma lista de filmes do banco de dados
        //ainda operação sincrona...mudar depois para assincrona
        public List<Filme> Listar()
        {
            return _context.Filme.ToList();

        }

        //metodo de inserir 
        public void Inserir(Filme filme)
        {
            //impedir filme com o mesmo Titulo
            var result = from obj in _context.Filme select obj;
            if (result.Any(x => x.Titulo == filme.Titulo))
            {
                return;
            }

            _context.Add(filme);
            _context.SaveChanges();
        }

        //metodo para encontrar por id
        public Filme EncontrarPorId(int id)
        {
            return _context.Filme.FirstOrDefault(obj => obj.Id == id);
        }

        //metodo remover
        public void Remove(int id)
        {
            var obj = _context.Filme.Find(id);
            _context.Filme.Remove(obj);
            _context.SaveChanges();
        }

        //metodo update
        public void Update(Filme filme)
        {
            _context.Update(filme);
            _context.SaveChanges();
        }
    }
}
