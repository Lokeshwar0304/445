using System;

namespace WebBrowser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.urlbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button5 = new System.Windows.Forms.Button();
            this.encTextBox = new System.Windows.Forms.TextBox();
            this.encrypt_btn = new System.Windows.Forms.Button();
            this.decrypt_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.copy_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.quoteTextBox = new System.Windows.Forms.TextBox();
            this.quote_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // urlbox
            // 
            this.urlbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlbox.Location = new System.Drawing.Point(67, 67);
            this.urlbox.Name = "urlbox";
            this.urlbox.Size = new System.Drawing.Size(1792, 41);
            this.urlbox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1905, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(67, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 53);
            this.button2.TabIndex = 2;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(284, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 53);
            this.button3.TabIndex = 3;
            this.button3.Text = "Forward";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(2469, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 50);
            this.button4.TabIndex = 4;
            this.button4.Text = "Home";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(37, 207);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(3658, 1548);
            this.webBrowser1.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(2280, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(158, 50);
            this.button5.TabIndex = 5;
            this.button5.Text = "Refresh";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // encTextBox
            // 
            this.encTextBox.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encTextBox.Location = new System.Drawing.Point(587, 1367);
            this.encTextBox.Name = "encTextBox";
            this.encTextBox.Size = new System.Drawing.Size(968, 53);
            this.encTextBox.TabIndex = 7;
            this.encTextBox.Text = "Please enter a message to encrypt/decrypt";
            this.encTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.encTextBox.TextChanged += new System.EventHandler(this.encTextBox_TextChanged);
            // 
            // encrypt_btn
            // 
            this.encrypt_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encrypt_btn.Location = new System.Drawing.Point(671, 1466);
            this.encrypt_btn.Name = "encrypt_btn";
            this.encrypt_btn.Size = new System.Drawing.Size(173, 70);
            this.encrypt_btn.TabIndex = 8;
            this.encrypt_btn.Text = "Encrypt";
            this.encrypt_btn.UseVisualStyleBackColor = true;
            this.encrypt_btn.Click += new System.EventHandler(this.encrypt_btn_Click);
            // 
            // decrypt_btn
            // 
            this.decrypt_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decrypt_btn.Location = new System.Drawing.Point(969, 1466);
            this.decrypt_btn.Name = "decrypt_btn";
            this.decrypt_btn.Size = new System.Drawing.Size(174, 70);
            this.decrypt_btn.TabIndex = 9;
            this.decrypt_btn.Text = "Decrypt";
            this.decrypt_btn.UseVisualStyleBackColor = true;
            this.decrypt_btn.Click += new System.EventHandler(this.decrypt_btn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(593, 1574);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 49);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // copy_btn
            // 
            this.copy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copy_btn.Location = new System.Drawing.Point(1270, 1466);
            this.copy_btn.Name = "copy_btn";
            this.copy_btn.Size = new System.Drawing.Size(184, 70);
            this.copy_btn.TabIndex = 11;
            this.copy_btn.Text = "Copy";
            this.copy_btn.UseVisualStyleBackColor = true;
            this.copy_btn.Click += new System.EventHandler(this.copy_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(742, 1294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(629, 59);
            this.label3.TabIndex = 13;
            this.label3.Text = "Encryption-Decryption Service";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2218, 1294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 59);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stock Quote Service";
            // 
            // quoteTextBox
            // 
            this.quoteTextBox.Font = new System.Drawing.Font("Calibri", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quoteTextBox.Location = new System.Drawing.Point(2108, 1367);
            this.quoteTextBox.Name = "quoteTextBox";
            this.quoteTextBox.Size = new System.Drawing.Size(618, 53);
            this.quoteTextBox.TabIndex = 15;
            this.quoteTextBox.Text = "Please enter a stock symbol";
            this.quoteTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.quoteTextBox.TextChanged += new System.EventHandler(this.quoteTextBox_TextChanged);
            // 
            // quote_btn
            // 
            this.quote_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quote_btn.Location = new System.Drawing.Point(2307, 1466);
            this.quote_btn.Name = "quote_btn";
            this.quote_btn.Size = new System.Drawing.Size(185, 70);
            this.quote_btn.TabIndex = 16;
            this.quote_btn.Text = "Get Quote";
            this.quote_btn.UseVisualStyleBackColor = true;
            this.quote_btn.Click += new System.EventHandler(this.quote_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2133, 1574);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 49);
            this.label5.TabIndex = 17;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3597, 1767);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.quote_btn);
            this.Controls.Add(this.quoteTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copy_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decrypt_btn);
            this.Controls.Add(this.encrypt_btn);
            this.Controls.Add(this.encTextBox);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.urlbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
        #endregion

        private System.Windows.Forms.TextBox urlbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox encTextBox;
        private System.Windows.Forms.Button encrypt_btn;
        private System.Windows.Forms.Button decrypt_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button copy_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox quoteTextBox;
        private System.Windows.Forms.Button quote_btn;
        private System.Windows.Forms.Label label5;
    }
}

