using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogoflix.Models
{
    [Serializable]
    public class InteresseFilme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Título do Filme")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public InteresseFilme()
        {

        }

        public InteresseFilme(int id, string titulo, string email)
        {
            Id = id;
            Titulo = titulo;
            Email = email;
        }
    }
}
