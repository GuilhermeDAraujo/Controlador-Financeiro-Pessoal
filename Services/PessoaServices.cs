using Microsoft.EntityFrameworkCore;
using Projeto_Controlador_Financeiro_Pessoal.Context;
using Projeto_Controlador_Financeiro_Pessoal.Models;

namespace Projeto_Controlador_Financeiro_Pessoal.Services
{
    public class PessoaServices
    {
        private readonly ControladorFinanceiroContext _context;
        public PessoaServices(ControladorFinanceiroContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> ListarTodasPessoas()
        {
            return await _context.Pessoas.OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<Pessoa> CreateAsyn(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync();
            }
            return pessoa;
        }

        public async Task<Pessoa> UpdateAsyn(Pessoa pessoa)
        {
            if (_context.Pessoas.Any(p => p.Id == pessoa.Id))
            {
                _context.Update(pessoa);
                await _context.SaveChangesAsync();
            }
            return pessoa;
        }

        public async Task<Pessoa> DeleteAsyn(Pessoa pessoa)
        {
            if (_context.Pessoas.Any(p => p.Id == pessoa.Id))
            {
                _context.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
            return pessoa;
        }

        public async Task<Pessoa> BuscarPessoaAsyn(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }
    }
}