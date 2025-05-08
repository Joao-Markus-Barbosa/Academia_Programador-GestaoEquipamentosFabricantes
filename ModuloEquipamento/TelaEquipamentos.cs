using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento
{
    public class TelaEquipamento
    {
        public static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- MENU DE EQUIPAMENTOS -----");
                Console.WriteLine("1 - Cadastrar equipamento");
                Console.WriteLine("2 - Listar equipamentos");
                Console.WriteLine("3 - Editar equipamento");
                Console.WriteLine("4 - Excluir equipamento");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": Cadastrar(); break;
                    case "2": Listar(); break;
                    case "3": Editar(); break;
                    case "4": Excluir(); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida. Pressione Enter para continuar."); Console.ReadLine(); break;
                }
            }
        }

        private static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("---- Cadastro de Equipamento ----");

            Console.Write("Nome (mínimo 6 caracteres): ");
            string nome = Console.ReadLine();
            if (nome.Length < 6)
            {
                Console.WriteLine("Nome deve ter no mínimo 6 caracteres.");
                Console.ReadLine();
                return;
            }

            Console.Write("Preço de aquisição: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Número de série: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Data de fabricação (dd/MM/yyyy): ");
            DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

            Console.Write("Fabricante: ");
            string fabricante = Console.ReadLine();

            Equipamento novoEquipamento = new Equipamento(0, nome, preco, numeroSerie, dataFabricacao, fabricante);
            RepositorioEquipamento.Adicionar(novoEquipamento);

            Console.WriteLine("Equipamento cadastrado com sucesso!");
            Console.ReadLine();
        }

        private static void Listar()
        {
            Console.Clear();
            Console.WriteLine("---- Lista de Equipamentos ----");

            var equipamentos = RepositorioEquipamento.ObterTodos();

            if (equipamentos.Count == 0)
            {
                Console.WriteLine("Nenhum equipamento cadastrado.");
            }
            else
            {
                foreach (var e in equipamentos)
                {
                    Console.WriteLine($"ID: {e.Id} | Nome: {e.Nome} | Preço: R${e.Preco} | Nº Série: {e.NumeroSerie} | Data Fab.: {e.DataFabricacao.ToShortDateString()} | Fabricante: {e.Fabricante}");
                }
            }

            Console.ReadLine();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("---- Edição de Equipamento ----");
            Listar();

            Console.Write("Digite o ID do equipamento que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Novo Preço: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Novo Número de Série: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Nova Data de Fabricação (dd/MM/yyyy): ");
            DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

            Console.Write("Novo Fabricante: ");
            string fabricante = Console.ReadLine();

            RepositorioEquipamento.Editar(id, nome, preco, numeroSerie, dataFabricacao, fabricante);

            Console.WriteLine("Equipamento atualizado com sucesso!");
            Console.ReadLine();
        }

        private static void Excluir()
        {
            Console.Clear();
            Console.WriteLine("---- Exclusão de Equipamento ----");
            Listar();

            Console.Write("Digite o ID do equipamento que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            RepositorioEquipamento.Remover(id);

            Console.WriteLine("Equipamento removido com sucesso!");
            Console.ReadLine();
        }
    }
}

