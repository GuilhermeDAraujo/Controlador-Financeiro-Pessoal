using Microsoft.AspNetCore.Mvc;
using Projeto_Controlador_Financeiro_Pessoal.Services;

namespace Projeto_Controlador_Financeiro_Pessoal.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaServices _pessoaServices;
        
        public PessoaController(PessoaServices pessoaServices)
        {
            _pessoaServices = pessoaServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pessoaServices.ListarTodasPessoas());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Update()
        {
            return View();
        }
    }
}