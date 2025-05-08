using Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;

namespace Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado
{
    public class TelaChamado
    {
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
                    default: Console.WriteLine("Opção inválida. Pressione Enter para continuar."); Console.ReadLine(); break;
                }
            }
        }

        private static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("---- Cadastro de Chamado ----");

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Escolha o equipamento pelo ID:");
            var equipamentos = RepositorioEquipamento.ObterTodos();
            foreach (var e in equipamentos)
            {
                Console.WriteLine($"ID: {e.Id} | Nome: {e.Nome}");
            }

            int idEquipamento = int.Parse(Console.ReadLine());
            Equipamento equipamentoEscolhido = RepositorioEquipamento.ObterPorId(idEquipamento);

            if (equipamentoEscolhido == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                Console.ReadLine();
                return;
            }

            Console.Write("Data de abertura (dd/MM/yyyy): ");
            DateTime dataAbertura = DateTime.Parse(Console.ReadLine());

            Chamado novoChamado = new Chamado(0, titulo, descricao, equipamentoEscolhido, dataAbertura);
            RepositorioChamado.Adicionar(novoChamado);

            Console.WriteLine("Chamado cadastrado com sucesso!");
            Console.ReadLine();
        }

        private static void Listar()
        {
            Console.Clear();
            Console.WriteLine("---- Lista de Chamados ----");

            var chamados = RepositorioChamado.ObterTodos();

            if (chamados.Count == 0)
            {
                Console.WriteLine("Nenhum chamado cadastrado.");
            }
            else
            {
                foreach (var c in chamados)
                {
                    Console.WriteLine($"ID: {c.Id} | Título: {c.Titulo} | Equipamento: {c.Equipamento.Nome} | Abertura: {c.DataAbertura.ToShortDateString()} | Dias em aberto: {c.DiasEmAberto()}");
                }
            }

            Console.ReadLine();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("---- Edição de Chamado ----");
            Listar();

            Console.Write("Digite o ID do chamado que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Novo Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Nova Descrição: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Escolha o novo equipamento pelo ID:");
            var equipamentos = RepositorioEquipamento.ObterTodos();
            foreach (var e in equipamentos)
            {
                Console.WriteLine($"ID: {e.Id} | Nome: {e.Nome}");
            }

            int idEquipamento = int.Parse(Console.ReadLine());
            Equipamento equipamentoEscolhido = RepositorioEquipamento.ObterPorId(idEquipamento);

            if (equipamentoEscolhido == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                Console.ReadLine();
                return;
            }

            Console.Write("Nova Data de abertura (dd/MM/yyyy): ");
            DateTime dataAbertura = DateTime.Parse(Console.ReadLine());

            RepositorioChamado.Editar(id, titulo, descricao, equipamentoEscolhido, dataAbertura);

            Console.WriteLine("Chamado atualizado com sucesso!");
            Console.ReadLine();
        }

        private static void Excluir()
        {
            Console.Clear();
            Console.WriteLine("---- Exclusão de Chamado ----");
            Listar();

            Console.Write("Digite o ID do chamado que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            RepositorioChamado.Remover(id);

            Console.WriteLine("Chamado removido com sucesso!");
            Console.ReadLine();
        }
    }
}

