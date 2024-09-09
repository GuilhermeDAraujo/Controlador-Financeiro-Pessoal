using Microsoft.EntityFrameworkCore;
using Projeto_Controlador_Financeiro_Pessoal.Context;
using Projeto_Controlador_Financeiro_Pessoal.Enums;
using Projeto_Controlador_Financeiro_Pessoal.Models;

namespace Projeto_Controlador_Financeiro_Pessoal.Services
{
    public class LancamentoService
    {
        private readonly ControladorFinanceiroContext _context;

        public LancamentoService(ControladorFinanceiroContext context)
        {
            _context = context;
        }

        public async Task<List<Lancamento>> BuscarTodosLancamentos()
        {
            return await _context.Lancamentos
                .Include(p => p.Pessoa)
                .Include(b => b.Banco)
                .OrderByDescending(l => l.DataCompra)
                .ToListAsync();
        }

        public async Task<Lancamento> CreateAsync(Lancamento lancamento)
        {
            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<Lancamento> UpdateAsync(Lancamento lancamento)
        {
            _context.Update(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<List<Pessoa>> BuscarTodasPessoasAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<List<Banco>> BuscarTodosBancosAsync()
        {
            return await _context.Bancos.ToListAsync();
        }

        public List<TipoPagamento> BuscarTodosTiposPagamentos()
        {
            return Enum.GetValues(typeof(TipoPagamento))
                .Cast<TipoPagamento>()
                .ToList();
        }

        public async Task<Lancamento> BuscarLancamentoPeloIdAsync(int id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }

        public async Task<bool> LancamentoJaExiteAsyn(int id)
        {
            return await _context.Lancamentos.AnyAsync(l => l.Id == id);
        }

        public async Task<Lancamento> BuscarLanca(int id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }   
    }
}