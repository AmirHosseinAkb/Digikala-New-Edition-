using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.Generators
{
    public  class ApplicationMessages
    {
        public const string DuplicatedEmail = "این ایمیل از قبل وجود دارد";
        public const string DuplicatedPhone = "این شماره همراه از قبل وجود دارد";
        public const string RecordNotFound = "کاربری با اطلاعات وارد شده یافت نشد.";
        public static string WrongUserPass = "رمز عبور وارد شده صحیح نمی باشد";
        public const string InvalidEmailOrPhoneNumber = "ایمیل یا شماره همراه را بصورت صحیح وارد کنید";
        public const string InvalidPhoneNumber = "شماره همراه را بصورت صحیح وارد کنید";
        public const string InvalidEmail = "ایمیل را بصورت صحیح وارد کنید";
        public const string InvalidAccountNumber = "شماره حساب خود را بصورت صحیح وارد کنید";
        public const string ProcessFailed = "عملیات با شکست مواجه شد لطفا دوباره امتحان نمایید";
        public const string ActivationProcessFailed = "عملیات فعال سازی با شکست مواجه شد لطفا بعدا دوباره امتحان نمایید.";
        public const string UserIsNotActive = "حساب کاربری شما فعال نمی باشد لطفا ابتدا حساب کاربری خود را فعال نمایید";
        public const string InvalidCurrentPassword = "رمز عبور فعلی خود را بصورت صحیح وارد کنید";
        public const string IdenticalEmailEntered = "ایمیلی غیر از ایمیل فعلی تان را وارد کنید";
        public const string IdenticalPhoneNumberEntered = "شماره ای غیر از شماره همراه فعلی تان را وارد کنید";
        public const string RoleNotExist = "نقش انتخاب شده وجود ندارد";

    }
}
