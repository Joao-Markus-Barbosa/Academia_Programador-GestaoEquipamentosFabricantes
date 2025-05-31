using Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;
using System;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante
{
    public class TelaFabricante
    {
        private static RepositorioFabricante repositorio = new RepositorioFabricante();

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
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("---- Cadastro de Fabricante ----");

            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Telefone: ");
                string telefone = Console.ReadLine();

                int novoId = GerarNovoId();
                Fabricante novoFabricante = new Fabricante(novoId, nome, email, telefone);
                repositorio.Cadastrar(novoFabricante);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Fabricante cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.ResetColor();
            Console.ReadLine();
        }

        private static void Listar()
        {
            Console.Clear();
            Console.WriteLine("---- Lista de Fabricantes ----");

            var lista = repositorio.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum fabricante cadastrado.");
            }
            else
            {
                foreach (var f in lista)
                    f.ExibirInformacoes();
            }

            Console.ReadLine();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("---- Edição de Fabricante ----");
            Listar();

            try
            {
                Console.Write("Digite o ID do fabricante que deseja editar: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Novo Nome: ");
                string novoNome = Console.ReadLine();

                Console.Write("Novo Email: ");
                string novoEmail = Console.ReadLine();

                Console.Write("Novo Telefone: ");
                string novoTelefone = Console.ReadLine();

                Fabricante fabricanteAtualizado = new Fabricante(id, novoNome, novoEmail, novoTelefone);
                repositorio.Editar(id, fabricanteAtualizado);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Fabricante atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.ResetColor();
            Console.ReadLine();
        }

        private static void Excluir()
        {
            Console.Clear();
            Console.WriteLine("---- Exclusão de Fabricante ----");
            Listar();

            try
            {
                Console.Write("Digite o ID do fabricante que deseja excluir: ");
                int id = int.Parse(Console.ReadLine());

                repositorio.Excluir(id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Fabricante removido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.ResetColor();
            Console.ReadLine();
        }

        private static int GerarNovoId()
        {
            var lista = repositorio.ListarTodos();
            if (lista.Count == 0) return 1;
            return lista[^1].Id + 1;
        }
    }
}

