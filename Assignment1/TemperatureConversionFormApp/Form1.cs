using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureConversionFormApp
{
    public partial class Form1 : Form
    {

        TempConvService.Service1Client tempConvService = new TempConvService.Service1Client(); // TemperatureConventionService Declaration
        string error_message = "Input is not in a correct format. Please enter a numeric value"; // Error Message if the input is not numeric

        public Form1()
        {
            InitializeComponent();
        }

        //This button is used to convert Celsius Value to Faranheit
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                int c2f_value = tempConvService.c2f(Convert.ToInt32(Math.Round(Double.Parse(textBox1.Text), MidpointRounding.AwayFromZero))); // calling c2f() method of TemperatureConventionService
                textBox2.Text = c2f_value.ToString()+ " °F";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(error_message);  
            }

        }

       

        //This button is used to convert Faranheit value to Celsius
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int f2c_value = tempConvService.f2c(Convert.ToInt32(Math.Round(Double.Parse(textBox1.Text), MidpointRounding.AwayFromZero))); // calling f2c() method of TemperatureConventionService
                textBox2.Text = f2c_value.ToString() + " °C";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(error_message);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
