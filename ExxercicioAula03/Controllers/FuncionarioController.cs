using ExxercicioAula03.Entities;
using ExxercicioAula03.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExxercicioAula03.Controllers
{
   public class FuncionarioController
    {
        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** CADASTRO DE FUNCIONARIO ***\n");
                var funcionario = new Funcionario();
                funcionario.IdFuncionario = Guid.NewGuid();
                Console.Write("Informe o nome do funcionario...............: ");
                funcionario.Nome = Console.ReadLine();
                Console.Write("Informe o cpf do funcionario................: ");
                funcionario.Cpf = Console.ReadLine();
                Console.Write("Informe a data de contratação do funcionario.: ");
                funcionario.Data = DateTime.Parse(Console.ReadLine());
                Console.Write("Informe o tel do funcionario................: ");
                funcionario.Telefone= Console.ReadLine();
                
                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Create(funcionario);
                
                Console.WriteLine("\nFuncionario cadastrado com sucesso!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nErro de validação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao cadastrar: {e.Message}");
            }
            finally
            {
                if (DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    CadastrarFuncionario();
                }
            }
        }
        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** ATUALIZAÇÃO DO FUNCIONARIO ***\n");
                Console.Write("Informe o Id do funcionario.................: ");
                var idFuncionario = Guid.Parse(Console.ReadLine());
                //consultando pessoa através do ID..

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario= funcionarioRepository.GetById(idFuncionario);

                //verificando se nenhum registro foi encontrado
                if (funcionario == null)
                    throw new ArgumentException("O ID informado não existe no banco de dados.");
                   
                var desejaAtualizar = false;
                Console.Write("\nDeseja alterar o nome? (S,N)..........: ");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);
                
                if (desejaAtualizar)
                {
                    Console.Write("Informe o Nome do funcionario............: ");
                    funcionario.Nome = Console.ReadLine();
                }
                Console.Write("\nDeseja alterar o CPF? (S,N)..................: ");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);
          
                if (desejaAtualizar)
                {
                    Console.Write("Informe o CPF da funcionario..................: ");
                    funcionario.Cpf = Console.ReadLine();
                }
                
                Console.Write("\nDeseja alterar a Data de contratação? (S,N)......: ");
                desejaAtualizar = Console.ReadLine().Equals("S",StringComparison.OrdinalIgnoreCase);
               
                if (desejaAtualizar)
                {
                    Console.Write("Informe a Data de contratação do funcionario....: ");
                    funcionario.Data = DateTime.Parse(Console.ReadLine());
                }


                Console.Write("\nDeseja alterar Telefone Do Funcionario? (S,N)......: ");
                desejaAtualizar = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);

                if (desejaAtualizar)
                {
                    Console.Write("Informe o Telefone do funcionario....: ");
                    funcionario.Telefone = Console.ReadLine();
                }



                //atualizando os dados da pessoa
                funcionarioRepository.Update(funcionario);
                Console.WriteLine("\nFuncionario atualizada com sucesso!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nErro de validação: {e.Message}");
            }
             catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar: {e.Message}");
            }
            finally
            {
                if (DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    AtualizarFuncionario();
                }
            }
        }

        public void ExcluirFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** EXCLUSÃO DE FUNCIONARIO ***\n");

                Console.Write("Informe o Id do Funcionario.................: ");
                var idFuncionario = Guid.Parse(Console.ReadLine());

                //consultando pessoa através do ID..
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(idFuncionario);

                //verificando se nenhum registro foi encontrado
                if (funcionario == null)
                    throw new ArgumentException("O ID informado não existe no banco de dados.");

                //excluindo..
                funcionarioRepository.Delete(funcionario);

                Console.WriteLine("\nFuncionario excluída com sucesso!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nErro de validação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao Excluir: {e.Message}");
            }
            finally
            {
                if (DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    ExcluirFuncionario();
                }
            }
        }

        public void ConsultarFuncionario()
        {
            try
            {
                Console.WriteLine("\n *** CONSULTA DE PESSOAS ***\n");

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetAll();

                foreach (var item in funcionario)
                {
                    Console.WriteLine($"ID FUNCIONARIO..............: { item.IdFuncionario}");

                    Console.WriteLine($"NOME DO FUNCIONARIO.........: { item.Nome}");

                    Console.WriteLine($"CPF....................: { item.Cpf}");

                    Console.WriteLine($"DATA DE CONTRATAÇÃO.....: { item.Data.ToString("dd/MM/yyyy")}");

                    Console.WriteLine($"TELEFONE DO FUNCIONARIO.....: {item.Telefone}");

                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFalha ao atualizar: {e.Message}");
            }
            finally
            {
                if (DesejaRepetirOProcesso())
                {
                    Console.Clear();
                    ConsultarFuncionario();
                }
            }
        }



        //método para verificar se o usuário deseja repetir o processo
        private bool DesejaRepetirOProcesso()
        {
            Console.Write("\nDeseja repetir o processo? (S,N): ");
            var opcao = Console.ReadLine();
            return opcao != null && opcao.Equals
           ("S", StringComparison.OrdinalIgnoreCase);
        }
    }
}

    

