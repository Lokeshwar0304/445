using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlbox.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EncryptionService.ServiceClient encService = new EncryptionService.ServiceClient();

            try
            {
                if (!String.IsNullOrWhiteSpace(urlbox.Text)) //checks if the text box has data
                {
                    lblencrypted.Text = encService.Encrypt(urlbox.Text); //calls encrypt method and sets label to the output
                    lblconfirmation.Text = "Encrypted message: "; //sets label 

                    lbldecrypted.Text = encService.Decrypt(lblencrypted.Text); //calls decrypted method and sets label to the output
                }
                else
                {
                    lblconfirmation.Text = ""; //clears label
                    lbldecrypted.Text = ""; //clears label
                    lblencrypted.Text = "Please enter a message."; //error message if the text box is empty 
                }
            }
            catch (Exception ec)
            {
                lblencrypted.Text = ec.Message.ToString(); //prints exception in case something bad happens
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
    }
}
