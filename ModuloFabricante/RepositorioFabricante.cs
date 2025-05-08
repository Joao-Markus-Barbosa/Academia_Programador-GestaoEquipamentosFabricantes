using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante
{
    public class RepositorioFabricante
    {
        private static List<Fabricante> listaFabricantes = new List<Fabricante>();
        private static int contadorId = 1;

        public static void Adicionar(Fabricante fabricante)
        {
            fabricante.Id = contadorId++;
            listaFabricantes.Add(fabricante);
        }

        public static List<Fabricante> ObterTodos()
        {
            return listaFabricantes;
        }

        public static Fabricante ObterPorId(int id)
        {
            return listaFabricantes.FirstOrDefault(f => f.Id == id);
        }

        public static void Editar(int id, string novoNome, string novoEmail, string novoTelefone)
        {
            Fabricante fabricante = ObterPorId(id);
            if (fabricante != null)
            {
                fabricante.Nome = novoNome;
                fabricante.Email = novoEmail;
                fabricante.Telefone = novoTelefone;
            }
        }

        public static void Remover(int id)
        {
            Fabricante fabricante = ObterPorId(id);
            if (fabricante != null)
            {
                listaFabricantes.Remove(fabricante);
            }
        }

        public static int ContarEquipamentosDoFabricante(string nomeFabricante, List<Equipamento> equipamentos)
        {
            return equipamentos.Count(e => e.Fabricante == nomeFabricante);
        }
    }
}

