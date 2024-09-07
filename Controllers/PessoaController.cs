using Microsoft.AspNetCore.Mvc;
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
            return View(await _pessoaServices.ListarTodasPessoasAsync());
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
                if (await _pessoaServices.PessoaJaExsiteAsync(pessoa.CPF))
                {
                    ModelState.AddModelError("", "CPF já cadastrado.");
                    return View(pessoa);
                }
                await _pessoaServices.CreateAsyn(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Update(int id)
        {
            var pessoaBanco = await _pessoaServices.BuscarPessoaAsyn(id);
            if (pessoaBanco == null)
            {
                ModelState.AddModelError("", "Pessoa não encontrado.");
                return RedirectToAction(nameof(Index));
            }

            return View(pessoaBanco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                if (await _pessoaServices.PessoaJaExsiteAsync(pessoa.CPF))
                {
                    ModelState.AddModelError("", "CPF já cadastrado.");
                    return View(pessoa);
                }
                await _pessoaServices.UpdateAsyn(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var pessoaBanco = await _pessoaServices.BuscarPessoaAsyn(id);
            if (pessoaBanco == null)
            {
                ModelState.AddModelError("", "Pessoa não encontrado.");
                return RedirectToAction(nameof(Index));
            }

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