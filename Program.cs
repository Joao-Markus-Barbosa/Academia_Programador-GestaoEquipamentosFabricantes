using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante;

namespace Academia_Programador_GestaoEquipamentosFabricantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTÃO DE EQUIPAMENTOS ===");
                Console.WriteLine("1 - Equipamentos");
                Console.WriteLine("2 - Chamados");
                Console.WriteLine("3 - Fabricantes");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        TelaEquipamento.MostrarMenu();
                        break;
                    case "2":
                        TelaChamado.MostrarMenu();
                        break;
                    case "3":
                        TelaFabricante.MostrarMenu();
                        break;
                    case "0":
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione Enter para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
