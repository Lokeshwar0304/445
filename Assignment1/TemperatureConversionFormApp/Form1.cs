using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureConversionFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TempConvService.Service1Client c2fService = new TempConvService.Service1Client();
            int c2f_value = c2fService.c2f(Int32.Parse(textBox1.Text));
            textBox2.Text = c2f_value.ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TempConvService.Service1Client f2cService = new TempConvService.Service1Client();
            int f2c_value = f2cService.f2c(Int32.Parse(textBox1.Text));
            textBox2.Text = f2c_value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
