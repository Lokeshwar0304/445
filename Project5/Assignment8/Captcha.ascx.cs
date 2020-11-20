using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Captcha;

namespace Assignment8
{
    public partial class Captcha : System.Web.UI.UserControl
    {
        public Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string verifier = c.generateRandomString();
            var  b = Bitmap.FromStream(c.generateCaptcha(verifier));
            
        }
    }
}