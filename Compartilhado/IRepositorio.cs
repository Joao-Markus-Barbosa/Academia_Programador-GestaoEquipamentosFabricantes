using System.Collections.Generic;

namespace Academia_Programador_GestaoEquipamentosFabricantes.Compartilhado
{
    public interface IRepositorio<T>
    {
        void Cadastrar(T entidade);
        void Editar(int id, T entidadeAtualizada);
        void Excluir(int id);
        List<T> ListarTodos();
        T SelecionarPorId(int id);
    }
}
