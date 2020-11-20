using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TryItWebApplication
{
    public partial class About : Page
    {
        XMLoperationsService.Service1Client xmlOps = new XMLoperationsService.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            lboutput.Visible = false;
        }

        protected void bnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                lboutput.Visible = false ;
                
                if (string.IsNullOrWhiteSpace(tbss.Text) || string.IsNullOrEmpty(tbxml.Text))
                {
                    lboutput.Text = "Please enter XML URL / Xpath Expression";
                    lboutput.Visible = true;
                    lboutput.ForeColor = Color.Red;
                }
                else
                {
                    var output = xmlOps.XPathSearch(tbxml.Text, tbss.Text);
                    if (output.Length > 0)
                    {
                        lboutput.Text = String.Format("<pre>{0}</pre>", HttpUtility.HtmlEncode(output));
                        lboutput.Visible = true;
                        lboutput.ForeColor = Color.Blue;
                    }
                    else
                    {
                        lboutput.Text = "NO DATA AVAILABLE FOR THE GIVEN PATH EXPRESSION";
                        lboutput.Visible = true;
                        lboutput.ForeColor = Color.Red;
                    }
                }
            }
            catch(Exception ex)
            {
                lboutput.Text = ex.Message;
                lboutput.Visible = true;
                lboutput.ForeColor = Color.Red;
            }
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            lboutput.Visible = false;
            tbxml.Text = "";
            tbss.Text = "";
        }
    }
}