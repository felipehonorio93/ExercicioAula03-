using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExxercicioAula03.Validations
{
    public class DataValidation
    {
        public static bool IsValid(DateTime data)
        {
            return (data != null && data != DateTime.MinValue);

        }
    }
}
