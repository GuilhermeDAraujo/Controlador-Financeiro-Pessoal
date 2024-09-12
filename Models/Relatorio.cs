using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Controlador_Financeiro_Pessoal.Models
{
    public class Relatorio
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public int? BancoId { get; set; }
        public int? PessoaId { get; set; }

        public List<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
        public List<DataPagamento> DataPagamentos { get; set; } = new List<DataPagamento>();

        public decimal TotalAVista
        {
            get
            {
                return Lancamentos.Sum(t => t.ValorTotal);
            }
        }

        public decimal? TotalParcelado
        {
            get
            {
                return DataPagamentos.Sum(tc => tc.ValorParcelado);
            }
        }
    }
}