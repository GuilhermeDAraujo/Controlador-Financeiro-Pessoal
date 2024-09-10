using Microsoft.EntityFrameworkCore;
using Projeto_Controlador_Financeiro_Pessoal.Models;

namespace Projeto_Controlador_Financeiro_Pessoal.Context
{
    public class ControladorFinanceiroContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<PessoaBanco> PessoaBancos { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<DataPagamento> DataPagamentos {get;set;}

        public ControladorFinanceiroContext(DbContextOptions<ControladorFinanceiroContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaBanco>()
                .HasKey(pb => new { pb.PessoaId, pb.BancoId });

            modelBuilder.Entity<PessoaBanco>()
                .HasOne(pb => pb.Pessoa)
                .WithMany(p => p.PessoaBancos)
                .HasForeignKey(pb => pb.PessoaId);

            modelBuilder.Entity<PessoaBanco>()
                .HasOne(pb => pb.Banco)
                .WithMany(b => b.PessoaBancos)
                .HasForeignKey(pb => pb.BancoId);

            modelBuilder.Entity<Lancamento>()
                .HasOne(l => l.Pessoa)
                .WithMany(p => p.Lancamentos)
                .HasForeignKey(l => l.PessoaId);

            modelBuilder.Entity<Lancamento>()
                .HasOne(l => l.Banco)
                .WithMany(b => b.Lancamentos)
                .HasForeignKey(l => l.BancoId);

            modelBuilder.Entity<Lancamento>()
                .Property(l => l.TipoPagamento)
                .HasConversion<int>();

            modelBuilder.Entity<DataPagamento>()
                .HasOne(l => l.Lancamento)
                .WithMany(dp => dp.DataPagamentos)
                .HasForeignKey(p => p.LancamentoId);
        }
    }
}