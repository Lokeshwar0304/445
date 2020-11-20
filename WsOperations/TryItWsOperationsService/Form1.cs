using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryItWsOperationsService
{
    public partial class Form1 : Form
    {
        WsOperationsService.WsOperationsServiceClient wsOpService = new WsOperationsService.WsOperationsServiceClient();
        
        
        public Form1()
        {
            InitializeComponent();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var output = wsOpService.WsOperations(textBox1.Text.ToString());
                display_Output(output);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void display_Output(string[] output)
        {
            TableLayoutPanel panel = tableLayoutPanel1;
            panel.ColumnCount = 3;
            panel.RowCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            
            panel.Controls.Add(new Label() { Text = "Operation Name" }, 1, 0);
            panel.Controls.Add(new Label() { Text = "Input Parameters" }, 2, 0);
            panel.Controls.Add(new Label() { Text = "Return Type" }, 3, 0);

            // For Add New Row (Loop this code for add multiple rows)
            foreach (var row in output)
            {
                string[] colvalues = row.Split(',');
                panel.RowCount = panel.RowCount + 1;
                panel.Controls.Add(new Label() { Text = colvalues[0] }, 1, panel.RowCount - 1);
                panel.Controls.Add(new Label() { Text = colvalues[1] }, 2, panel.RowCount - 1);
                panel.Controls.Add(new Label() { Text = colvalues[2]}, 3, panel.RowCount - 1);
            }
        }


    }
}