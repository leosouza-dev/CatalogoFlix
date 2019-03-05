using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogoflix.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Título do Filme")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Digite o Resumo")]
        public string Resumo { get; set; }

        [Required(ErrorMessage = "Digite a Descrição Completa")]
        [StringLength(200, ErrorMessage = "O tamanho máximo são 200 caracteres.")]
        [Display(Name = "Descrição Completa")]
        public string DescricaoCompleta { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Lançamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataLancamento { get; set; }

        //pensar em mudar
        [Required(ErrorMessage = "Digite o Estilo do Filme")]
        public string Estilo { get; set; }

        public Filme()
        {
                
        }

        public Filme(int id, string titulo, string resumo, string descricaoCompleta, DateTime dataLancamento, string estilo)
        {
            Id = id;
            Titulo = titulo;
            Resumo = resumo;
            DescricaoCompleta = descricaoCompleta;
            DataLancamento = dataLancamento;
            Estilo = estilo;
        }

        //
    }
}
