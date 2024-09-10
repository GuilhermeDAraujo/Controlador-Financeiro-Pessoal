using Microsoft.AspNetCore.Mvc;
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
                .Include(dp => dp.DataPagamentos)
                .OrderByDescending(l => l.DataCompra)
                .ToListAsync();
        }

        public async Task<bool> CreateAsync(Lancamento lancamento)
        {
            if (lancamento == null)
                return false;

            await _context.Lancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
            await AdicionarParcelaAsync(lancamento);
            return true;
        }

        public async Task AdicionarParcelaAsync(Lancamento lancamento)
        {
            var novasParcelas = new List<DataPagamento>();
            if (lancamento.NumeroParcelas > 0)
            {
                for (int i = 0; i < lancamento.NumeroParcelas; i++)
                {
                    DateTime dataPagamento = lancamento.DataCompra.AddMonths(i + 1); //Adiciona mais 1 mes na Data da Compra
                    decimal valorParcela = lancamento.ValorTotal / lancamento.NumeroParcelas; //Calcula o valor de cada Parcela

                    novasParcelas.Add(new DataPagamento
                    {
                        LancamentoId = lancamento.Id,
                        Data = dataPagamento,
                        ValorParcelado = valorParcela
                    });
                }
                await _context.DataPagamentos.AddRangeAsync(novasParcelas);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Lancamento> DeleteAsync(Lancamento lancamento)
        {
            if (await _context.Lancamentos.AnyAsync(l => l.Id == lancamento.Id))
            {
                _context.Remove(lancamento);
                await _context.SaveChangesAsync();
            }
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
    }
}