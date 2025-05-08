using Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante
{
    public class TelaFabricante
    {
        public static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- MENU DE FABRICANTES -----");
                Console.WriteLine("1 - Cadastrar fabricante");
                Console.WriteLine("2 - Listar fabricantes");
                Console.WriteLine("3 - Editar fabricante");
                Console.WriteLine("4 - Excluir fabricante");
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
            Console.WriteLine("---- Cadastro de Fabricante ----");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Fabricante novoFabricante = new Fabricante(0, nome, email, telefone);
            RepositorioFabricante.Adicionar(novoFabricante);

            Console.WriteLine("Fabricante cadastrado com sucesso!");
            Console.ReadLine();
        }

        private static void Listar()
        {
            Console.Clear();
            Console.WriteLine("---- Lista de Fabricantes ----");

            var fabricantes = RepositorioFabricante.ObterTodos();
            var equipamentos = RepositorioEquipamento.ObterTodos();

            if (fabricantes.Count == 0)
            {
                Console.WriteLine("Nenhum fabricante cadastrado.");
            }
            else
            {
                foreach (var f in fabricantes)
                {
                    int totalEquipamentos = RepositorioFabricante.ContarEquipamentosDoFabricante(f.Nome, equipamentos);
                    Console.WriteLine($"ID: {f.Id} | Nome: {f.Nome} | Email: {f.Email} | Telefone: {f.Telefone} | Qtde Equipamentos: {totalEquipamentos}");
                }
            }

            Console.ReadLine();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("---- Edição de Fabricante ----");
            Listar();

            Console.Write("Digite o ID do fabricante que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo Nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("Novo Email: ");
            string novoEmail = Console.ReadLine();

            Console.Write("Novo Telefone: ");
            string novoTelefone = Console.ReadLine();

            RepositorioFabricante.Editar(id, novoNome, novoEmail, novoTelefone);

            Console.WriteLine("Fabricante atualizado com sucesso!");
            Console.ReadLine();
        }

        private static void Excluir()
        {
            Console.Clear();
            Console.WriteLine("---- Exclusão de Fabricante ----");
            Listar();

            Console.Write("Digite o ID do fabricante que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            RepositorioFabricante.Remover(id);

            Console.WriteLine("Fabricante removido com sucesso!");
            Console.ReadLine();
        }
    }
}

