using System.Collections.Generic;

namespace GestaoEquipamentosWeb.Domain.Interfaces
{
    public interface IRepositorio<T>
    {
        void Inserir(T entidade);
        void Editar(T entidade);
        void Excluir(int id);
        T SelecionarPorId(int id);
        List<T> SelecionarTodos();
    }
}
