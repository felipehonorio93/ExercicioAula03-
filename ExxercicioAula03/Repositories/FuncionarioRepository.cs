using Dapper;
using ExxercicioAula03.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExxercicioAula03.Repositories
{
    public class FuncionarioRepository
    {
        #region Atributos
        private string _connectionString;

        #endregion

        public FuncionarioRepository()
        {
            #region Construtores
            _connectionString = @"Data Source=DESKTOP-82QFCQ6\SQLEXPRESS;   
                                  Initial Catalog=BDExercicioAula03; 
                                  Integrated Security=True;Connect Timeout=30;
                                  Encrypt=False;    
                                  TrustServerCertificate=False;
                                  ApplicationIntent=ReadWrite;
                                  MultiSubnetFailover=False";
            #endregion
        }

        public void Create(Funcionario funcionario)
        {
            //escrevendo uma query sql
            var sql = @"
                     INSERT INTO FUNCIONARIO(IDFUNCIONARIO, NOME, CPF, DATANASCIMENTO, TELEFONE)
                     VALUES(@IdFuncionario, @Nome, @Cpf, @Data, @Telefone)
 ";
            //abrindo conexão com o banco de dados do SqlServer
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando SQL
                connection.Execute(sql, funcionario);
            }

        }
        public void Update(Funcionario funcionario)
        {
            var sql = @"UPDATE FUNCIONARIO SET
                        NOME             =@Nome, 
                        CPF              =@Cpf, 
                        DATANASCIMENTO   =@Data, 
                        TELEFONE         =@Telefone 
                        WHERE 
                            IDFUNCIONARIO =@IdFuncionario";

            //abrindo conexão com o banco de dados do SqlServer
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando SQL
                connection.Execute(sql, funcionario);
            }
        }

        public void Delete(Funcionario funcionario)
        {
            var sql = @"
                    DELETE FROM FUNCIONARIO
                    WHERE IDFUNCIONARIO = @IdFuncionario
                    ";

            //abrindo conexão com o banco de dados do SqlServer
            using (var connection = new SqlConnection(_connectionString))
            {
                //executando o comando SQL
                connection.Execute(sql, funcionario);
            }
        }

        
        /// <summary>
        /// Método para retornar uma lista com todas as pessoas cadastradas
        /// </summary>
        public List<Funcionario> GetAll()
        {
            var sql = @"
                SELECT * FROM FUNCIONARIO
                ORDER BY NOME
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>(sql).ToList();
            }
        }

        /// <summary>
        /// Método para retornar uma pessoa baseado no ID
        /// </summary>

        public Funcionario GetById(Guid idFuncionario)
        {
            var sql = @"
                        SELECT * FROM FUNCIONARIO
                        WHERE IDFUNCIONARIO = @idFuncionario
                        ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>
               (sql, new { idFuncionario }).FirstOrDefault();
            }
        }


    }
}
