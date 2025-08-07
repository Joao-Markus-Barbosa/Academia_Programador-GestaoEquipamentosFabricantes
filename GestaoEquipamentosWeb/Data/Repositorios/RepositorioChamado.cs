using GestaoEquipamentosWeb.Domain.Entities;
using GestaoEquipamentosWeb.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GestaoEquipamentosWeb.Data.Repositories
{
    public class RepositorioChamado : IRepositorio<Chamado>
    {
        private readonly string _caminhoArquivo = Path.Combine(
            Directory.GetCurrentDirectory(), "DataStorage", "chamados.json");

        private List<Chamado> _chamados;
        private static int contadorId = 1;

        public RepositorioChamado()
        {
            _chamados = JsonStorage.CarregarDeArquivo<Chamado>(_caminhoArquivo);

            if (_chamados.Any())
                contadorId = _chamados.Max(c => c.Id) + 1;
        }

        public void Inserir(Chamado entidade)
        {
            if (entidade == null) return;

            entidade.Id = contadorId++;
            _chamados.Add(entidade);
            Salvar();
        }

        public void Editar(Chamado entidade)
        {
            var existente = SelecionarPorId(entidade.Id);
            if (existente == null) return;

            existente.Titulo = entidade.Titulo;
            existente.Descricao = entidade.Descricao;
            existente.DataAbertura = entidade.DataAbertura;
            existente.EquipamentoId = entidade.EquipamentoId;

            Salvar();
        }

        public void Excluir(int id)
        {
            var existente = SelecionarPorId(id);
            if (existente != null)
            {
                _chamados.Remove(existente);
                Salvar();
            }
        }

        public Chamado SelecionarPorId(int id)
        {
            return _chamados.FirstOrDefault(c => c.Id == id);
        }

        public List<Chamado> SelecionarTodos()
        {
            return _chamados;
        }

        private void Salvar()
        {
            Console.WriteLine($"[DEBUG] Salvando chamados em: {_caminhoArquivo}");
            JsonStorage.SalvarEmArquivo(_caminhoArquivo, _chamados);
        }
    }
}

