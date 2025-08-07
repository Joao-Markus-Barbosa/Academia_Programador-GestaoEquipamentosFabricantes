using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestaoEquipamentosWeb.Domain.Entities;
using GestaoEquipamentosWeb.Data.Repositories;

namespace GestaoEquipamentosWeb.Controllers
{
    public class EquipamentosController : Controller
    {
        private readonly RepositorioEquipamento _repositorioEquipamento = new();
        private readonly RepositorioFabricante _repositorioFabricante = new();

        public IActionResult Index()
        {
            var lista = _repositorioEquipamento.SelecionarTodos();
            foreach (var equipamento in lista)
            {
                equipamento.Fabricante = _repositorioFabricante.SelecionarPorId(equipamento.FabricanteId);
            }
            return View(lista);
        }

        public IActionResult Create()
        {
            ViewBag.Fabricantes = new SelectList(_repositorioFabricante.SelecionarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipamento equipamento)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Fabricantes = new SelectList(_repositorioFabricante.SelecionarTodos(), "Id", "Nome");
                return View(equipamento);
            }

            _repositorioEquipamento.Inserir(equipamento);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var equipamento = _repositorioEquipamento.SelecionarPorId(id);
            if (equipamento == null)
                return NotFound();

            ViewBag.Fabricantes = new SelectList(_repositorioFabricante.SelecionarTodos(), "Id", "Nome", equipamento.FabricanteId);
            return View(equipamento);
        }

        [HttpPost]
        public IActionResult Edit(Equipamento equipamento)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Fabricantes = new SelectList(_repositorioFabricante.SelecionarTodos(), "Id", "Nome", equipamento.FabricanteId);
                return View(equipamento);
            }

            _repositorioEquipamento.Editar(equipamento);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var equipamento = _repositorioEquipamento.SelecionarPorId(id);
            if (equipamento == null)
                return NotFound();

            equipamento.Fabricante = _repositorioFabricante.SelecionarPorId(equipamento.FabricanteId);
            return View(equipamento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmarExclusao(int id)
        {
            _repositorioEquipamento.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
