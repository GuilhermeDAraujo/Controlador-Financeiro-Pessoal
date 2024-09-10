using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Controlador_Financeiro_Pessoal.Models;
using Projeto_Controlador_Financeiro_Pessoal.Services;

namespace Projeto_Controlador_Financeiro_Pessoal.Controllers
{
    public class LancamentoController : Controller
    {
        private readonly LancamentoService _lancamentoService;

        public LancamentoController(LancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _lancamentoService.BuscarTodosLancamentos());
        }

        public async Task<IActionResult> Create()
        {
            await CarregarViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                bool sucesso = await _lancamentoService.CreateAsync(lancamento);

                if (!sucesso)
                {
                    ModelState.AddModelError("", "Lançamento não realizado");
                    await CarregarViewBag();
                    return View(lancamento);
                }
                return RedirectToAction(nameof(Index));
            }

            await CarregarViewBag();
            return View(lancamento);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lancamento = await _lancamentoService.BuscarLancamentoPeloIdAsync(id);
            if (lancamento == null)
            {
                ModelState.AddModelError("", "Lançamento não encontrado.");
                return RedirectToAction(nameof(Index));
            }
            await CarregarViewBag();
            return View(lancamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Lancamento lancamento)
        {
            await _lancamentoService.DeleteAsync(lancamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task CarregarViewBag()
        {
            ViewBag.Pessoa = new SelectList(await _lancamentoService.BuscarTodasPessoasAsync(), "Id", "Nome");
            ViewBag.Banco = new SelectList(await _lancamentoService.BuscarTodosBancosAsync(), "Id", "NomeBanco");
            ViewBag.TipoPagamento = new SelectList(_lancamentoService.BuscarTodosTiposPagamentos());
        }
    }
}