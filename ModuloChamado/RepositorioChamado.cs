using Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado
{
    public class RepositorioChamado
    {
        private static List<Chamado> listaChamados = new List<Chamado>();
        private static int contadorId = 1;

        public static void Adicionar(Chamado chamado)
        {
            chamado.Id = contadorId++;
            listaChamados.Add(chamado);
        }

        public static List<Chamado> ObterTodos()
        {
            return listaChamados;
        }

        public static Chamado ObterPorId(int id)
        {
            return listaChamados.FirstOrDefault(c => c.Id == id);
        }

        public static void Editar(int id, string novoTitulo, string novaDescricao, Equipamento novoEquipamento, DateTime novaDataAbertura)
        {
            Chamado chamado = ObterPorId(id);
            if (chamado != null)
            {
                chamado.Titulo = novoTitulo;
                chamado.Descricao = novaDescricao;
                chamado.Equipamento = novoEquipamento;
                chamado.DataAbertura = novaDataAbertura;
            }
        }

        public static void Remover(int id)
        {
            Chamado chamado = ObterPorId(id);
            if (chamado != null)
            {
                listaChamados.Remove(chamado);
            }
        }
    }
}

