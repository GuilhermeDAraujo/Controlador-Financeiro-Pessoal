using Microsoft.EntityFrameworkCore;
using Projeto_Controlador_Financeiro_Pessoal.Context;
using Projeto_Controlador_Financeiro_Pessoal.Models;

namespace Projeto_Controlador_Financeiro_Pessoal.Services
{
    public class RelatorioServices
    {
        private readonly ControladorFinanceiroContext _context;

        public RelatorioServices(ControladorFinanceiroContext context)
        {
            _context = context;
        }

        public async Task<Relatorio> RelatorioComprasAVista(Relatorio relatorio)
        {   
            relatorio.Lancamentos = await _context.Lancamentos
                .Where(l => (!relatorio.DataInicio.HasValue || l.DataCompra >= relatorio.DataInicio)//Data sendo opcional, igual os demais
                    &&(! relatorio.DataFinal.HasValue || l.DataCompra <= relatorio.DataFinal))
                .Where(l => !relatorio.BancoId.HasValue || l.BancoId == relatorio.BancoId) //Se !relatorio.BancoId.HasValue tiver valor(false) executa o outro critério
                .Where(l => !relatorio.PessoaId.HasValue || l.PessoaId == relatorio.PessoaId)//Se !relatorio.PessoaId.HasValue tiver valor(false) executa o outro critério
                .Where(p => p.NumeroParcelas == 0)
                .Include(p => p.Pessoa)
                .Include(b => b.Banco)
                .OrderByDescending(x => x.DataCompra)
                .ToListAsync();
            return relatorio;
        }

        public async Task<List<Pessoa>> BuscarTodasPessoasAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<List<Banco>> BuscarTodosBancosAsync()
        {
            return await _context.Bancos.ToListAsync();
        }
    }
}