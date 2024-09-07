using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projeto_Controlador_Financeiro_Pessoal.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await _pessoaServices.CreateAsyn(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var pessoaBanco = await _pessoaServices.BuscarPessoaAsyn(id);
            if (pessoaBanco == null)
                return RedirectToAction(nameof(Index));

            return View(pessoaBanco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await _pessoaServices.UpdateAsyn(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            var pessoaBanco = await _pessoaServices.BuscarPessoaAsyn(id);
            if (pessoaBanco == null)
                return RedirectToAction(nameof(Index));

            return View(pessoaBanco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Pessoa pessoa)
        {
            await _pessoaServices.DeleteAsyn(pessoa);
            return RedirectToAction(nameof(Index));
        }
    }
}