namespace Projeto_Controlador_Financeiro_Pessoal.Models
{
    public class PessoaBanco
    {
        public int PessoaId {get;set;}
        public int BancoId {get;set;}
        public Pessoa Pessoa {get;set;}
        public Banco Banco {get;set;}
    }
}