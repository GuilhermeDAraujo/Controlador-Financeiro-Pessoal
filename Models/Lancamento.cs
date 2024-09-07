using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Controlador_Financeiro_Pessoal.Enums;

namespace Projeto_Controlador_Financeiro_Pessoal.Models
{
    public class Lancamento
    {
        public int Id {get;set;}
        [Required(ErrorMessage ="Informe a data da compra.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataCompra {get;set;}
        [Required(ErrorMessage ="Informe o valor da compra.")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public decimal Valor {get;set;}
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage ="{0} deve conter entre {2} e {1} caracteres.")]
        public string Descricao {get;set;}
        public int PessoaId {get;set;}
        public int BancoId {get;set;}
        [Required(ErrorMessage ="Obrigatório informar o tipo da pagamento!")]
        public TipoPagamento TipoPagamento {get;set;}
        public Pessoa Pessoa {get;set;}
        public Banco Banco {get;set;}
    }
}