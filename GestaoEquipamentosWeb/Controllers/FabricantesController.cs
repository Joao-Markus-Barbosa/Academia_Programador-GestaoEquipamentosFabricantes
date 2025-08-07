using Microsoft.AspNetCore.Mvc;
using GestaoEquipamentosWeb.Domain.Entities;
using GestaoEquipamentosWeb.Data.Repositories;

namespace GestaoEquipamentosWeb.Controllers
{
    public class FabricantesController : Controller
    {
        private readonly RepositorioFabricante _repositorio = new();

        public IActionResult Index()
        {
            var lista = _repositorio.SelecionarTodos();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fabricante fabricante)
        {
            if (!ModelState.IsValid)
                return View(fabricante);

            _repositorio.Inserir(fabricante);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var fabricante = _repositorio.SelecionarPorId(id);
            if (fabricante == null)
                return NotFound();

            return View(fabricante);
        }

        [HttpPost]
        public IActionResult Edit(Fabricante fabricante)
        {
            if (!ModelState.IsValid)
                return View(fabricante);

            _repositorio.Editar(fabricante);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var fabricante = _repositorio.SelecionarPorId(id);
            if (fabricante == null)
                return NotFound();

            return View(fabricante);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmarExclusao(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
