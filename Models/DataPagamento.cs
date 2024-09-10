using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Controlador_Financeiro_Pessoal.Models
{
    public class DataPagamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a data da compra.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informe o valor da compra.")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? ValorParcelado { get; set; }

        public int LancamentoId { get; set; }
        public Lancamento Lancamento { get; set; }
    }
}