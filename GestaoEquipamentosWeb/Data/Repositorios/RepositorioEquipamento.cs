using GestaoEquipamentosWeb.Domain.Entities;
using GestaoEquipamentosWeb.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GestaoEquipamentosWeb.Data.Repositories
{
    public class RepositorioEquipamento : IRepositorio<Equipamento>
    {
        private readonly string _caminhoArquivo = Path.Combine(
            Directory.GetCurrentDirectory(), "DataStorage", "equipamentos.json");

        private List<Equipamento> _equipamentos;
        private static int contadorId = 1;

        public RepositorioEquipamento()
        {
            _equipamentos = JsonStorage.CarregarDeArquivo<Equipamento>(_caminhoArquivo);

            if (_equipamentos.Any())
                contadorId = _equipamentos.Max(e => e.Id) + 1;
        }

        public void Inserir(Equipamento entidade)
        {
            if (entidade == null) return;

            entidade.Id = contadorId++;
            _equipamentos.Add(entidade);
            Salvar();
        }

        public void Editar(Equipamento entidade)
        {
            var existente = SelecionarPorId(entidade.Id);
            if (existente == null) return;

            existente.Nome = entidade.Nome;
            existente.NumeroSerie = entidade.NumeroSerie;
            existente.DataAquisicao = entidade.DataAquisicao;
            existente.FabricanteId = entidade.FabricanteId;

            Salvar();
        }

        public void Excluir(int id)
        {
            var existente = SelecionarPorId(id);
            if (existente != null)
            {
                _equipamentos.Remove(existente);
                Salvar();
            }
        }

        public Equipamento SelecionarPorId(int id)
        {
            return _equipamentos.FirstOrDefault(e => e.Id == id);
        }

        public List<Equipamento> SelecionarTodos()
        {
            return _equipamentos;
        }

        private void Salvar()
        {
            Console.WriteLine($"[DEBUG] Salvando equipamentos em: {_caminhoArquivo}");
            JsonStorage.SalvarEmArquivo(_caminhoArquivo, _equipamentos);
        }


    }
}



