using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Controlador_Financeiro_Pessoal.Models
{
    public class Pessoa
    {
        public int Id {get;set;}
        [Required(ErrorMessage ="Informe o {0}.")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres.")]
        public string Nome {get;set;}
        [Required(ErrorMessage ="Informe o {0}.")]
        [StringLength(11)]
        public string CPF {get;set;}
        [Required(ErrorMessage ="Informe o {0}.")]
        [EmailAddress(ErrorMessage ="Informe um Email válido!")]
        public string Email {get;set;}

        public ICollection<PessoaBanco> PessoaBancos {get;set;}
        public ICollection<Lancamento> Lancamentos {get;set;}
    }
}