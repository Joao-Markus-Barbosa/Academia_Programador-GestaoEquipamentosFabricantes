using Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;
using System;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado
{
    public class TelaChamado
    {
        private static RepositorioChamado repositorio = new RepositorioChamado();
        private static RepositorioEquipamentos repositorioEquipamentos = new RepositorioEquipamentos();

        public static void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- MENU DE CHAMADOS -----");
                Console.WriteLine("1 - Cadastrar chamado");
                Console.WriteLine("2 - Listar chamados");
                Console.WriteLine("3 - Editar chamado");
                Console.WriteLine("4 - Excluir chamado");
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
            Console.WriteLine("---- Cadastro de Chamado ----");

            try
            {
                Console.Write("Título: ");
                string titulo = Console.ReadLine();

                Console.Write("Descrição: ");
                string descricao = Console.ReadLine();

                var equipamentos = repositorioEquipamentos.ListarTodos();
                if (equipamentos.Count == 0)
                    throw new Exception("Nenhum equipamento disponível.");

                Console.WriteLine("Escolha o equipamento pelo ID:");
                foreach (var e in equipamentos)
                    Console.WriteLine($"ID: {e.Id} | Nome: {e.Nome}");

                Console.Write("ID do Equipamento: ");
                int idEquipamento = int.Parse(Console.ReadLine());
                Equipamento equipamentoEscolhido = repositorioEquipamentos.SelecionarPorId(idEquipamento);

                if (equipamentoEscolhido == null)
                    throw new Exception("Equipamento não encontrado.");

                Console.Write("Data de abertura (dd/MM/yyyy): ");
                DateTime dataAbertura = DateTime.Parse(Console.ReadLine());

                int novoId = GerarNovoId();
                Chamado chamado = new Chamado(novoId, titulo, descricao, equipamentoEscolhido, dataAbertura);
                repositorio.Cadastrar(chamado);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chamado cadastrado com sucesso!");
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
            Console.WriteLine("---- Lista de Chamados ----");

            var lista = repositorio.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum chamado cadastrado.");
            }
            else
            {
                foreach (var c in lista)
                    c.ExibirInformacoes();
            }

            Console.ReadLine();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("---- Edição de Chamado ----");
            Listar();

            try
            {
                Console.Write("Digite o ID do chamado que deseja editar: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Novo Título: ");
                string titulo = Console.ReadLine();

                Console.Write("Nova Descrição: ");
                string descricao = Console.ReadLine();

                var equipamentos = repositorioEquipamentos.ListarTodos();
                if (equipamentos.Count == 0)
                    throw new Exception("Nenhum equipamento disponível.");

                Console.WriteLine("Escolha o novo equipamento pelo ID:");
                foreach (var e in equipamentos)
                    Console.WriteLine($"ID: {e.Id} | Nome: {e.Nome}");

                Console.Write("ID do Equipamento: ");
                int idEquipamento = int.Parse(Console.ReadLine());
                Equipamento equipamentoEscolhido = repositorioEquipamentos.SelecionarPorId(idEquipamento);

                if (equipamentoEscolhido == null)
                    throw new Exception("Equipamento não encontrado.");

                Console.Write("Nova Data de abertura (dd/MM/yyyy): ");
                DateTime dataAbertura = DateTime.Parse(Console.ReadLine());

                Chamado chamadoAtualizado = new Chamado(id, titulo, descricao, equipamentoEscolhido, dataAbertura);
                repositorio.Editar(id, chamadoAtualizado);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chamado atualizado com sucesso!");
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
            Console.WriteLine("---- Exclusão de Chamado ----");
            Listar();

            try
            {
                Console.Write("Digite o ID do chamado que deseja excluir: ");
                int id = int.Parse(Console.ReadLine());

                repositorio.Excluir(id);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chamado removido com sucesso!");
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

