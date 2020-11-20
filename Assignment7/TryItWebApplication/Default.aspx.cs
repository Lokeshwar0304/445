using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItWebApplication
{
    public partial class _Default : Page
    {
        XMLoperationsService.Service1Client xmlOps = new XMLoperationsService.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbmessage.Visible = false;
        }

        protected void bnvalidate_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(string.IsNullOrWhiteSpace(tbxml.Text) || string.IsNullOrWhiteSpace(tbxsd.Text))
                {
                    lbmessage.Text = "Please enter a URL";
                    lbmessage.Visible = true;
                    lbmessage.ForeColor = Color.Red;
                }
                if(!tbxml.Text.EndsWith(".xml") || !tbxsd.Text.EndsWith(".xsd"))
                {
                    lbmessage.Text = "Please enter a valid .xml or .xsd URL";
                    lbmessage.Visible = true;
                    lbmessage.ForeColor = Color.Red;
                }
                else
                {
                    string result = xmlOps.verification(tbxml.Text, tbxsd.Text);
                    lbmessage.Text = result;
                    lbmessage.Visible = true;
                    lbmessage.ForeColor = Color.Black;

                }
            }
            catch(Exception ex)
            {
                lbmessage.Text = ex.Message;
                lbmessage.Visible = true;
                lbmessage.ForeColor = Color.Red;


            }
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            lbmessage.Visible = false;
            tbxml.Text = "";
            tbxsd.Text = "";
        }
    }
}