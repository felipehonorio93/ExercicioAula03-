using ExxercicioAula03.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExxercicioAula03.Entities
{
    public class Funcionario
    {
        #region Atributos
        private Guid _idFuncionario;
        private string _nome;
        private string _cpf;
        private string _telefone;
        private DateTime _data;
        #endregion

        #region Propriedades 
        public Guid IdFuncionario {

            get => _idFuncionario;

            set
            {
                if (!IdValidation.IsValid(value))
                 throw new ArgumentException("Id Do Funcionário é inválido"); 
                
                _idFuncionario = value;
            }
        }

        public string Nome
        {
            get => _nome;
        
            set
            {
                if (!NomeValidation.IsValid(value))
                    throw new ArgumentException("O nome do Funcionario é inválido"); 
                _nome= value;            
            }
        }



        public string Cpf
        {
            get => _cpf;
            set
            {
                if (!CpfValidation.IsValid(value))
                    throw new ArgumentException("O Cpf do Funmcionario é´inválido");                 
                _cpf= value;
            }
        }

        public DateTime Data
        {
            get => _data;
            set 
            {
                if (!DataValidation.IsValid(value))
                    throw new ArgumentException("A data do Funcionario é inválido"); 
                _data = value; 
            
            }
        }

        public string Telefone
        {
            get=> _telefone;
            set 
            {
                if (!TelefoneValidation.Isvalid(value))
                    throw new ArgumentException("O número de telefone é inválido"); 

                
                _telefone= value;
            }
        }

        #endregion
    }
}
