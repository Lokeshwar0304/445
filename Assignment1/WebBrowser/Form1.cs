using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        EncryptionService.ServiceClient encService = new EncryptionService.ServiceClient(); //Encryption Service declaration
        StockQuoteService.ServiceClient stockService = new StockQuoteService.ServiceClient(); // Stock Quote Service declaration

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlbox.Text); // To Navigate to required URL
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
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

       
        // To encrypt user message
        private void encrypt_btn_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Enabled = true;
            try
            {
                if (!String.IsNullOrWhiteSpace(encTextBox.Text)) 
                {

                    
                    label1.Text = "Encrypted message: " + encService.Encrypt(encTextBox.Text); //Calls Encrypt method
                    copy_btn.Enabled = true;

                }
                  
                else
                {
                    
                    label1.Text = "Please enter a message to Encrypt/Decrypt"; 
                }
            }
            catch(Exception ex)
            {
                label1.Text = ex.Message;
                
            }
        }

        // To decrypt user message
        private void decrypt_btn_Click_1(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Enabled = true;

            try
            {
                
                if (!String.IsNullOrWhiteSpace(encTextBox.Text))
                {

                    label1.Text = "Decrypted message: " + encService.Decrypt(encTextBox.Text); //Calls Decrypt method
                    copy_btn.Enabled = true;
                }

                else
                {

                    label1.Text = "Please enter a message to Encrypt/Decrypt";
                }
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
                
            }
        }

        private void encTextBox_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            copy_btn.Enabled = false;
        }

        //To copy the encrypted or decrypted message
        private void copy_btn_Click(object sender, EventArgs e)
        {
            if(label1.Text.Length>0) Clipboard.SetText(label1.Text.Split(':')[1]);
        }
    }
}
