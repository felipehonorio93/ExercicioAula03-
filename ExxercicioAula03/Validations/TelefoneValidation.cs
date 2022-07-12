using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExxercicioAula03.Validations
{
    public class TelefoneValidation
    {
        public static bool Isvalid(string telefone)
        {
            var regex = new Regex("^[0-9]{11}$");
            return regex.IsMatch(telefone);    
        }
    }
}
