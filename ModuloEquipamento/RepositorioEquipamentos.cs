using System.Collections.Generic;
using Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento
{
    public class RepositorioEquipamentos : IRepositorio<Equipamento>
    {
        private List<Equipamento> equipamentos = new List<Equipamento>();

        public void Cadastrar(Equipamento entidade)
        {
            equipamentos.Add(entidade);
        }

        public void Editar(int id, Equipamento entidadeAtualizada)
        {
            Equipamento equipamentoExistente = SelecionarPorId(id);
            if (equipamentoExistente != null)
            {
                equipamentoExistente.Nome = entidadeAtualizada.Nome;
                equipamentoExistente.Preco = entidadeAtualizada.Preco;
                equipamentoExistente.NumeroSerie = entidadeAtualizada.NumeroSerie;
                equipamentoExistente.DataFabricacao = entidadeAtualizada.DataFabricacao;
                equipamentoExistente.Fabricante = entidadeAtualizada.Fabricante;
            }
        }

        public void Excluir(int id)
        {
            Equipamento equipamentoExistente = SelecionarPorId(id);
            if (equipamentoExistente != null)
                equipamentos.Remove(equipamentoExistente);
        }

        public List<Equipamento> ListarTodos()
        {
            return new List<Equipamento>(equipamentos);
        }

        public Equipamento SelecionarPorId(int id)
        {
            return equipamentos.Find(e => e.Id == id);
        }
    }
}


