using Academia_Programador_GestaoEquipamentosFabricantes.ModuloEquipamento;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloChamado;
using Academia_Programador_GestaoEquipamentosFabricantes.ModuloFabricante;
using System;

namespace Academia_Programador_GestaoEquipamentosFabricantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== SISTEMA DE GESTÃO DE EQUIPAMENTOS ===");
                Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nEncerrando o programa... Até logo!");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida. Pressione Enter para continuar.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
