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

        public async Task<Relatorio> RelatorioComprasAVistaAsync(Relatorio relatorio)
        {   
            relatorio.Lancamentos = await _context.Lancamentos
                .Where(l => (!relatorio.DataInicio.HasValue || l.DataCompra >= relatorio.DataInicio)//Data sendo opcional, igual os demais
                    &&(! relatorio.DataFinal.HasValue || l.DataCompra <= relatorio.DataFinal))
                .Where(l => !relatorio.BancoId.HasValue || l.BancoId == relatorio.BancoId) //Se !relatorio.BancoId.HasValue tiver valor(false) executa o outro critério
                .Where(l => !relatorio.PessoaId.HasValue || l.PessoaId == relatorio.PessoaId)//Se !relatorio.PessoaId.HasValue tiver valor(false) executa o outro critério
                .Where(p => p.NumeroParcelas == 0)
                .Include(p => p.Pessoa)
                .Include(b => b.Banco)
                .OrderBy(x => x.DataCompra)
                .ToListAsync();
            return relatorio;
        }

        public async Task<Relatorio> RelatorioComprasNoCreditoAsync(Relatorio relatorio)
        {
            relatorio.DataPagamentos = await _context.DataPagamentos
                .Where(l => (!relatorio.DataInicio.HasValue || l.Data >= relatorio.DataInicio)
                    &&(!relatorio.DataFinal.HasValue || l.Data <= relatorio.DataFinal))
                .Where(l => !relatorio.BancoId.HasValue || l.Lancamento.BancoId == relatorio.BancoId)
                .Where(l => !relatorio.PessoaId.HasValue || l.Lancamento.PessoaId == relatorio.PessoaId)
                .Include(p => p.Lancamento.Pessoa)
                .Include(b => b.Lancamento.Banco)
                .OrderBy(x => x.Data)
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