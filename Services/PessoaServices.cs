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
    }
}