using GestaoEquipamentosWeb.Domain.Entities;
using GestaoEquipamentosWeb.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GestaoEquipamentosWeb.Data.Repositories
{
    public class RepositorioFabricante : IRepositorio<Fabricante>
    {
        private readonly string _caminhoArquivo = Path.Combine(
            Directory.GetCurrentDirectory(), "DataStorage", "fabricantes.json");

        private List<Fabricante> _fabricantes;
        private static int contadorId = 1;

        public RepositorioFabricante()
        {
            _fabricantes = JsonStorage.CarregarDeArquivo<Fabricante>(_caminhoArquivo);

            if (_fabricantes.Any())
                contadorId = _fabricantes.Max(f => f.Id) + 1;
        }

        public void Inserir(Fabricante entidade)
        {
            if (entidade == null) return;

            entidade.Id = contadorId++;
            _fabricantes.Add(entidade);
            Salvar();
        }

        public void Editar(Fabricante entidade)
        {
            var existente = SelecionarPorId(entidade.Id);
            if (existente == null) return;

            existente.Nome = entidade.Nome;
            Salvar();
        }

        public void Excluir(int id)
        {
            var existente = SelecionarPorId(id);
            if (existente != null)
            {
                _fabricantes.Remove(existente);
                Salvar();
            }
        }

        public Fabricante SelecionarPorId(int id)
        {
            return _fabricantes.FirstOrDefault(f => f.Id == id);
        }

        public List<Fabricante> SelecionarTodos()
        {
            return _fabricantes;
        }

        private void Salvar()
        {
            Console.WriteLine($"[DEBUG] Salvando fabricantes em: {_caminhoArquivo}");
            JsonStorage.SalvarEmArquivo(_caminhoArquivo, _fabricantes);
        }


    }
}



