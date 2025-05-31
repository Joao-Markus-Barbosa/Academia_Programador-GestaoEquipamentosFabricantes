using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;
using System;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento
{
    public class TelaEquipamento
    {
        private static RepositorioEquipamentos repositorio = new RepositorioEquipamentos();

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
            Console.WriteLine("---- Cadastro de Equipamento ----");

            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Preço de aquisição: ");
                decimal preco = decimal.Parse(Console.ReadLine());

                Console.Write("Número de série: ");
                string numeroSerie = Console.ReadLine();

                Console.Write("Data de fabricação (dd/MM/yyyy): ");
                DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

                Console.Write("Fabricante: ");
                string fabricante = Console.ReadLine();

                int novoId = GerarNovoId();
                Equipamento novo = new Equipamento(novoId, nome, preco, numeroSerie, dataFabricacao, fabricante);
                repositorio.Cadastrar(novo);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Equipamento cadastrado com sucesso!");
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
            Console.WriteLine("---- Lista de Equipamentos ----");

            var lista = repositorio.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum equipamento cadastrado.");
            }
            else
            {
                foreach (var e in lista)
                    e.ExibirInformacoes();
            }

            Console.ReadLine();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("---- Edição de Equipamento ----");
            Listar();

            try
            {
                Console.Write("Digite o ID do equipamento que deseja editar: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Novo Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Novo Preço: ");
                decimal preco = decimal.Parse(Console.ReadLine());

                Console.Write("Novo Nº de Série: ");
                string numeroSerie = Console.ReadLine();

                Console.Write("Nova Data de Fabricação (dd/MM/yyyy): ");
                DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

                Console.Write("Novo Fabricante: ");
                string fabricante = Console.ReadLine();

                Equipamento atualizado = new Equipamento(id, nome, preco, numeroSerie, dataFabricacao, fabricante);
                repositorio.Editar(id, atualizado);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Equipamento atualizado com sucesso!");
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
            Console.WriteLine("---- Exclusão de Equipamento ----");
            Listar();

            try
            {
                Console.Write("Digite o ID do equipamento que deseja excluir: ");
                int id = int.Parse(Console.ReadLine());

                repositorio.Excluir(id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Equipamento removido com sucesso!");
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

