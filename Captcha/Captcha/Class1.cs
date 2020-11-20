using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha
{
    public class Class1
    {
        public static WSReposCaptchaService.ServiceClient captchaService = new WSReposCaptchaService.ServiceClient();


        public string generateRandomString()
        {
            Random random = new Random();
            int lenght = random.Next(4, 6);
            string randomString = captchaService.GetVerifierString(lenght.ToString());
            return randomString;
        }

        public Stream generateCaptcha(string randomString)
        {
            return captchaService.GetImage(randomString);

        }
    }
}
