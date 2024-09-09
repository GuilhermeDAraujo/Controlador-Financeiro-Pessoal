using System.ComponentModel.DataAnnotations;

namespace Projeto_Controlador_Financeiro_Pessoal.Models
{
    public class Banco
    {
        public int Id {get;set;}
        [Required(ErrorMessage ="Inform o Nome do banco.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage ="O Tamanho do Nome de contet entre {2} e {1} caracteres!")]
        public string NomeBanco {get;set;}

        public ICollection<PessoaBanco> PessoaBancos {get;set;} = new List<PessoaBanco>();
        public ICollection<Lancamento> Lancamentos {get;set;} = new List<Lancamento>();
    }
}