using ExxercicioAula03.Controllers;
namespace ExercicioAula03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n*** SISTEMA DE CONTROLE DE FUNCIONARIO * **\n");

                Console.WriteLine("(1) Cadastrar Funcionario");
                Console.WriteLine("(2) Atualizar Funcionario");
                Console.WriteLine("(3) Excluir Funcionario");
                Console.WriteLine("(4) Consultar Funcionario");

                Console.Write("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                var funcionarioController = new FuncionarioController();
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        funcionarioController.CadastrarFuncionario();
                        break;

                    case 2:
                        funcionarioController.AtualizarFuncionario();
                        break;

                    case 3:
                        funcionarioController.ExcluirFuncionario();
                        break;

                    case 4:
                        funcionarioController.ConsultarFuncionario();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha: {e.Message}");
            }
            finally
            {
                Console.Write("\nDeseja sair do programa? (S,N): ");
                var desejaSair = Console.ReadLine()
                      .Equals("S", StringComparison.OrdinalIgnoreCase);

                if (!desejaSair)
                {
                    Console.Clear();
                    Main(args);
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }
            }

            Console.ReadKey();
        }
    }
}



    