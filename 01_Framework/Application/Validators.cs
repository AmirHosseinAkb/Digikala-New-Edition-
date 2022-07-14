using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.Convertors
{
    public static class Validators
    {
        public static bool IsEmail(this string email)
        {
            try
            {
                var emailV = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhoneNumber(this string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Trim().Length != 11 || phone.Any(c=>char.IsLetter(c)))
                return false;

            return true;
        }
    }
}
