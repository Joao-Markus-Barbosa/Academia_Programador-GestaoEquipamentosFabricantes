using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento
{
    public class RepositorioEquipamento
    {
        private static List<Equipamento> listaEquipamentos = new List<Equipamento>();
        private static int contadorId = 1;

        public static void Adicionar(Equipamento equipamento)
        {
            equipamento.Id = contadorId++;
            listaEquipamentos.Add(equipamento);
        }

        public static List<Equipamento> ObterTodos()
        {
            return listaEquipamentos;
        }

        public static Equipamento ObterPorId(int id)
        {
            return listaEquipamentos.FirstOrDefault(e => e.Id == id);
        }

        public static void Editar(int id, string novoNome, decimal novoPreco, string novoNumeroSerie, DateTime novaData, string novoFabricante)
        {
            Equipamento equipamento = ObterPorId(id);
            if (equipamento != null)
            {
                equipamento.Nome = novoNome;
                equipamento.Preco = novoPreco;
                equipamento.NumeroSerie = novoNumeroSerie;
                equipamento.DataFabricacao = novaData;
                equipamento.Fabricante = novoFabricante;
            }
        }

        public static void Remover(int id)
        {
            Equipamento equipamento = ObterPorId(id);
            if (equipamento != null)
            {
                listaEquipamentos.Remove(equipamento);
            }
        }
    }
}

