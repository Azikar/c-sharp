namespace U1_12.Žaidimas
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
            this.Vykdyti = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Metai = new System.Windows.Forms.Label();
            this.Klausimai = new System.Windows.Forms.Label();
            this.rez = new System.Windows.Forms.RichTextBox();
            this.Baigti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Vykdyti
            // 
            this.Vykdyti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Vykdyti.Location = new System.Drawing.Point(12, 390);
            this.Vykdyti.Name = "Vykdyti";
            this.Vykdyti.Size = new System.Drawing.Size(111, 39);
            this.Vykdyti.TabIndex = 0;
            this.Vykdyti.Text = "Vykdyti";
            this.Vykdyti.UseVisualStyleBackColor = true;
            this.Vykdyti.Click += new System.EventHandler(this.Vykdyti_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox1.Location = new System.Drawing.Point(98, 291);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox2.Location = new System.Drawing.Point(98, 339);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 2;
            // 
            // Metai
            // 
            this.Metai.AutoSize = true;
            this.Metai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Metai.Location = new System.Drawing.Point(12, 291);
            this.Metai.Name = "Metai";
            this.Metai.Size = new System.Drawing.Size(50, 19);
            this.Metai.TabIndex = 3;
            this.Metai.Text = "Metai";
            // 
            // Klausimai
            // 
            this.Klausimai.AutoSize = true;
            this.Klausimai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Klausimai.Location = new System.Drawing.Point(12, 340);
            this.Klausimai.Name = "Klausimai";
            this.Klausimai.Size = new System.Drawing.Size(80, 19);
            this.Klausimai.TabIndex = 4;
            this.Klausimai.Text = "Klausymai";
            // 
            // rez
            // 
            this.rez.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rez.Location = new System.Drawing.Point(0, 0);
            this.rez.Name = "rez";
            this.rez.Size = new System.Drawing.Size(927, 278);
            this.rez.TabIndex = 5;
            this.rez.Text = "";
            // 
            // Baigti
            // 
            this.Baigti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Baigti.Location = new System.Drawing.Point(798, 390);
            this.Baigti.Name = "Baigti";
            this.Baigti.Size = new System.Drawing.Size(104, 34);
            this.Baigti.TabIndex = 6;
            this.Baigti.Text = "Baigti";
            this.Baigti.UseVisualStyleBackColor = true;
            this.Baigti.Click += new System.EventHandler(this.Baigti_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 434);
            this.Controls.Add(this.Baigti);
            this.Controls.Add(this.rez);
            this.Controls.Add(this.Klausimai);
            this.Controls.Add(this.Metai);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Vykdyti);
            this.Name = "Form1";
            this.Text = "Protmusis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Vykdyti;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Metai;
        private System.Windows.Forms.Label Klausimai;
        private System.Windows.Forms.RichTextBox rez;
        private System.Windows.Forms.Button Baigti;
    }
}

