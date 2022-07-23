using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.Generators.Email
{
    public interface IEmailService
    {
        void SendEmail(string to,string subject,string body);
    }
}
