using Microsoft.AspNetCore.Mvc;
using Projeto_Controlador_Financeiro_Pessoal.Models;
using Projeto_Controlador_Financeiro_Pessoal.Services;

namespace Projeto_Controlador_Financeiro_Pessoal.Controllers
{
    public class BancoController : Controller
    {
        private readonly BancoServices _bancoServices;

        public BancoController(BancoServices banco)
        {
            _bancoServices = banco;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _bancoServices.ListarTodosBancosAsync());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banco banco)
        {
            if (ModelState.IsValid)
            {
                if (await _bancoServices.BancoJaExisteAsync(banco.NomeBanco))
                {
                    ModelState.AddModelError("", "Banco já existe.");
                    return View(banco);
                }
                await _bancoServices.CreateAsync(banco);
                return RedirectToAction(nameof(Index));
            }
            return View(banco);
        }

        public async Task<IActionResult> Update(int id)
        {
            var banco = await _bancoServices.BuscarBancoAsync(id);
            if (banco == null)
            {
                ModelState.AddModelError("", "Banco não encontrado.");
                return RedirectToAction(nameof(Index));
            }

            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Banco banco)
        {
            if (ModelState.IsValid)
            {
                if (await _bancoServices.BancoJaExisteAsync(banco.NomeBanco))
                {
                    ModelState.AddModelError("", "Banco já existe.");
                    return View(banco);
                }
                await _bancoServices.UpdateAsync(banco);
                return RedirectToAction(nameof(Index));
            }
            return View(banco);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var banco = await _bancoServices.BuscarBancoAsync(id);
            if (banco == null)
            {
                ModelState.AddModelError("", "Banco não encontrado.");
                return RedirectToAction(nameof(Index));
            }

            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Banco banco)
        {
            await _bancoServices.DeleteAsync(banco);
            return RedirectToAction(nameof(Index));
        }
    }
}