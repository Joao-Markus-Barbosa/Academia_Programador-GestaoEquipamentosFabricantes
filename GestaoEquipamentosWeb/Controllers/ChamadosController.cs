using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestaoEquipamentosWeb.Domain.Entities;
using GestaoEquipamentosWeb.Data.Repositories;

namespace GestaoEquipamentosWeb.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly RepositorioChamado _repositorioChamado = new();
        private readonly RepositorioEquipamento _repositorioEquipamento = new();

        public IActionResult Index()
        {
            var lista = _repositorioChamado.SelecionarTodos();
            foreach (var chamado in lista)
            {
                chamado.Equipamento = _repositorioEquipamento.SelecionarPorId(chamado.EquipamentoId);
            }
            return View(lista);
        }

        public IActionResult Create()
        {
            ViewBag.Equipamentos = new SelectList(_repositorioEquipamento.SelecionarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Chamado chamado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Equipamentos = new SelectList(_repositorioEquipamento.SelecionarTodos(), "Id", "Nome", chamado.EquipamentoId);
                return View(chamado);
            }

            _repositorioChamado.Inserir(chamado);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var chamado = _repositorioChamado.SelecionarPorId(id);
            if (chamado == null)
                return NotFound();

            ViewBag.Equipamentos = new SelectList(_repositorioEquipamento.SelecionarTodos(), "Id", "Nome", chamado.EquipamentoId);
            return View(chamado);
        }

        [HttpPost]
        public IActionResult Edit(Chamado chamado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Equipamentos = new SelectList(_repositorioEquipamento.SelecionarTodos(), "Id", "Nome", chamado.EquipamentoId);
                return View(chamado);
            }

            _repositorioChamado.Editar(chamado);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var chamado = _repositorioChamado.SelecionarPorId(id);
            if (chamado == null)
                return NotFound();

            chamado.Equipamento = _repositorioEquipamento.SelecionarPorId(chamado.EquipamentoId);
            return View(chamado);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repositorioChamado.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
