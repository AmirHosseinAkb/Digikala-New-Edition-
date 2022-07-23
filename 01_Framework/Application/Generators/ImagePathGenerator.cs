using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application.Generators
{
    public class ImagePathGenerator
    {
        public static string GenerateUserImagePath(string imageName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "UserAvatar",
                imageName);
        }
    }
}
