using System.Collections.Generic;
using Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante
{
    public class RepositorioFabricante : IRepositorio<Fabricante>
    {
        private List<Fabricante> fabricantes = new List<Fabricante>();

        public void Cadastrar(Fabricante entidade)
        {
            fabricantes.Add(entidade);
        }

        public void Editar(int id, Fabricante entidadeAtualizada)
        {
            Fabricante fabricanteExistente = SelecionarPorId(id);
            if (fabricanteExistente != null)
            {
                fabricanteExistente.Nome = entidadeAtualizada.Nome;
                fabricanteExistente.Email = entidadeAtualizada.Email;
                fabricanteExistente.Telefone = entidadeAtualizada.Telefone;
            }
        }

        public void Excluir(int id)
        {
            Fabricante fabricanteExistente = SelecionarPorId(id);
            if (fabricanteExistente != null)
                fabricantes.Remove(fabricanteExistente);
        }

        public List<Fabricante> ListarTodos()
        {
            return new List<Fabricante>(fabricantes);
        }

        public Fabricante SelecionarPorId(int id)
        {
            return fabricantes.Find(f => f.Id == id);
        }
    }
}

