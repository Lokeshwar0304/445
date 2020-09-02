using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumberSortingWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            SortNumbersService.Service1Client sns = new SortNumbersService.Service1Client();
            string sorted_numbers = sns.sort(TextBox1.Text);
            TextBox2.Text = sorted_numbers;

        }
    }
}