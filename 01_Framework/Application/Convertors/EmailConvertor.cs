using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.Generators
{
    public class EmailConvertor
    {
        public static string FixEmail(string email)
        {
            if (email == null)
                return null;
            return email.ToLower().Replace(" ", "");
        }
    }
}
