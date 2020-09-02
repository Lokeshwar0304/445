namespace TemperatureConversionFormApp
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
            this.btn_c2f = new System.Windows.Forms.Button();
            this.btn_f2c = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_c2f
            // 
            this.btn_c2f.Location = new System.Drawing.Point(75, 125);
            this.btn_c2f.Name = "btn_c2f";
            this.btn_c2f.Size = new System.Drawing.Size(192, 50);
            this.btn_c2f.TabIndex = 0;
            this.btn_c2f.Text = "c2f";
            this.btn_c2f.UseVisualStyleBackColor = true;
            this.btn_c2f.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_f2c
            // 
            this.btn_f2c.Location = new System.Drawing.Point(390, 125);
            this.btn_f2c.Name = "btn_f2c";
            this.btn_f2c.Size = new System.Drawing.Size(188, 50);
            this.btn_f2c.TabIndex = 1;
            this.btn_f2c.Text = "f2c";
            this.btn_f2c.UseVisualStyleBackColor = true;
            this.btn_f2c.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 38);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Enter a value";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(222, 218);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(220, 38);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_f2c);
            this.Controls.Add(this.btn_c2f);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_c2f;
        private System.Windows.Forms.Button btn_f2c;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

