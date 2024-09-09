using Microsoft.EntityFrameworkCore;
using Projeto_Controlador_Financeiro_Pessoal.Context;
using Projeto_Controlador_Financeiro_Pessoal.Models;

namespace Projeto_Controlador_Financeiro_Pessoal.Services
{
    public class BancoServices
    {
        private readonly ControladorFinanceiroContext _context;

        public BancoServices(ControladorFinanceiroContext context)
        {
            _context = context;
        }


        public async Task<Banco> CreateAsync(Banco banco)
        {
            await _context.AddAsync(banco);
            await _context.SaveChangesAsync();
            return banco;
        }

        public async Task<Banco> UpdateAsync(Banco banco)
        {
            _context.Update(banco);
            await _context.SaveChangesAsync();
            return banco;
        }

        public async Task<Banco> DeleteAsync(Banco banco)
        {
            if (await _context.Bancos.AnyAsync(b => b.Id == banco.Id))
            {
                _context.Remove(banco);
                await _context.SaveChangesAsync();
            }
            return banco;
        }
        
        public async Task<List<Banco>> ListarTodosBancosAsync()
        {
            return await _context.Bancos.OrderBy(b => b.NomeBanco).ToListAsync();
        }

        public async Task<Banco> BuscarBancoAsync(int id)
        {
            return await _context.Bancos.FindAsync(id);
        }

        public async Task<bool> BancoJaExisteAsync(string nome)
        {
            return await _context.Bancos.AnyAsync(b => b.NomeBanco == nome);
        }
    }
}