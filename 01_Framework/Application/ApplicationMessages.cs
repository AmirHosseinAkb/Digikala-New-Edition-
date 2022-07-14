using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.Convertors
{
    public  class ApplicationMessages
    {
        public const string DuplicatedEmail = "این ایمیل از قبل وجود دارد";
        public const string DuplicatedPhone = "این شماره همراه از قبل وجود دارد";
        public const string RecordNotFound = "کاربری با اطلاعات وارد شده یافت نشد.";
        public static string WrongUserPass = "نام کاربری یا رمز عبور اشتباه است";
        public const string InvalidEmailOrPhoneNumber = "ایمیل یا شماره همراه را بصورت صحیح وارد کنید";
        public const string ActivationProcessFailed = "عملیات فعال سازی با شکست مواجه شد لطفا بعدا دوباره امتحان نمایید.";
        public const string UserIsNotActive = "حساب کاربری شما فعال نمی باشد لطفا ابتدا حساب کاربری خود را فعال نمایید";

    }
}
