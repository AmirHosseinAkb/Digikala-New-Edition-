using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application
{
    public class ValidationMessages
    {
        public const string IsRequired = "این فیلد نمی تواند خالی باشد";
        public const string MaxFileSize = "فایل حجیم تر از حد مجاز است";
        public const string InvalidFileFormat = "فرمت فایل مجاز نیست";
        public const string MaxLenght = "مقدار وارد شده بیش از طول مجاز است";
        public const string MinLength = "مقدار وارد شده کمتر از حد مجاز است";
        public const string PasswordMinLength = "رمز عبور حداقل باید 8 کاراکتر باشد";
        public const string InvalidPasswordCompare = "تکرار رمز عبور صحیح نمی باشد";
    }
}
