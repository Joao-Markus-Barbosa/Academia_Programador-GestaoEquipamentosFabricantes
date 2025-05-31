using System.Collections.Generic;
using Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado
{
    public class RepositorioChamado : IRepositorio<Chamado>
    {
        private List<Chamado> chamados = new List<Chamado>();

        public void Cadastrar(Chamado entidade)
        {
            chamados.Add(entidade);
        }

        public void Editar(int id, Chamado entidadeAtualizada)
        {
            Chamado chamadoExistente = SelecionarPorId(id);
            if (chamadoExistente != null)
            {
                chamadoExistente.Titulo = entidadeAtualizada.Titulo;
                chamadoExistente.Descricao = entidadeAtualizada.Descricao;
                chamadoExistente.Equipamento = entidadeAtualizada.Equipamento;
                chamadoExistente.DataAbertura = entidadeAtualizada.DataAbertura;
            }
        }

        public void Excluir(int id)
        {
            Chamado chamadoExistente = SelecionarPorId(id);
            if (chamadoExistente != null)
                chamados.Remove(chamadoExistente);
        }

        public List<Chamado> ListarTodos()
        {
            return new List<Chamado>(chamados);
        }

        public Chamado SelecionarPorId(int id)
        {
            return chamados.Find(c => c.Id == id);
        }
    }
}


