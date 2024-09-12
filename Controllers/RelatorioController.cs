using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Controlador_Financeiro_Pessoal.Models;
using Projeto_Controlador_Financeiro_Pessoal.Services;

namespace Projeto_Controlador_Financeiro_Pessoal.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly RelatorioServices _relatorioServices;

        public RelatorioController(RelatorioServices relatorioServices)
        {
            _relatorioServices = relatorioServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CarteiraDebito()
        {
            await CarregarViewBag();
            return View(new Relatorio());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarteiraDebito(Relatorio relatorio)
        {
            if (relatorio == null)
                return BadRequest("Relatório não pode ser nulo");

            relatorio = await _relatorioServices.RelatorioComprasAVistaAsync(relatorio);
            await CarregarViewBag();
            return View(relatorio);
        }

        public async Task<IActionResult> Credito()
        {
            await CarregarViewBag();
            return View(new Relatorio());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Credito(Relatorio relatorio)
        {
            if(relatorio == null)
                return BadRequest("Relatório não pode ser nulo");

            relatorio = await _relatorioServices.RelatorioComprasNoCreditoAsync(relatorio);
            await CarregarViewBag();
            return View(relatorio);
        }

        public async Task CarregarViewBag()
        {
            ViewBag.Pessoa = new SelectList(await _relatorioServices.BuscarTodasPessoasAsync(), "Id", "Nome");
            ViewBag.Banco = new SelectList(await _relatorioServices.BuscarTodosBancosAsync(), "Id", "NomeBanco");
        }

        public void PreservarDataRelatorios(Relatorio relatorio, DateTime? dataInicio, DateTime? dataFinal)
        {
            relatorio.DataInicio = dataInicio;
            relatorio.DataFinal = dataFinal;
        }
    }
}