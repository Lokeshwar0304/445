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
            TextBox2.Text = "";
            Console.WriteLine("tb1_tc_loki");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(TextBox1.Text))
            {
                SortNumbersService.Service1Client sns = new SortNumbersService.Service1Client();
                string sorted_numbers = sns.sort(TextBox1.Text); // Calls sort function of SortStringNumbersService
                TextBox2.Text = sorted_numbers;
            }
            else
            {
                TextBox2.Text = "Please enter some text.Example: 4,1,-5,2,0";
            }

            
        }
    }
}