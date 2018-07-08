namespace lab2_
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.atidarytiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.skaiciavimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kurSaugotiTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rikiuotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.papildytiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.failasToolStripMenuItem,
            this.skaiciavimasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 25);
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.atidarytiToolStripMenuItem,
            this.toolStripMenuItem3});
            this.failasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(61, 25);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // atidarytiToolStripMenuItem
            // 
            this.atidarytiToolStripMenuItem.Name = "atidarytiToolStripMenuItem";
            this.atidarytiToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.atidarytiToolStripMenuItem.Text = "Atidaryti";
            this.atidarytiToolStripMenuItem.Click += new System.EventHandler(this.atidarytiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(139, 26);
            this.toolStripMenuItem3.Text = "Baigti";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // skaiciavimasToolStripMenuItem
            // 
            this.skaiciavimasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.rikiuotToolStripMenuItem,
            this.salintToolStripMenuItem,
            this.papildytiToolStripMenuItem,
            this.kurSaugotiTxtToolStripMenuItem});
            this.skaiciavimasToolStripMenuItem.Enabled = false;
            this.skaiciavimasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.skaiciavimasToolStripMenuItem.Name = "skaiciavimasToolStripMenuItem";
            this.skaiciavimasToolStripMenuItem.Size = new System.Drawing.Size(111, 25);
            this.skaiciavimasToolStripMenuItem.Text = "Skaiciavimas";
            // 
            // kurSaugotiTxtToolStripMenuItem
            // 
            this.kurSaugotiTxtToolStripMenuItem.Enabled = false;
            this.kurSaugotiTxtToolStripMenuItem.Name = "kurSaugotiTxtToolStripMenuItem";
            this.kurSaugotiTxtToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.kurSaugotiTxtToolStripMenuItem.Text = "Kur saugoti csv";
            this.kurSaugotiTxtToolStripMenuItem.Click += new System.EventHandler(this.kurSaugotiTxtToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 26);
            this.toolStripMenuItem2.Text = "Atrinkti";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // rikiuotToolStripMenuItem
            // 
            this.rikiuotToolStripMenuItem.Name = "rikiuotToolStripMenuItem";
            this.rikiuotToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.rikiuotToolStripMenuItem.Text = "Rikiuot";
            this.rikiuotToolStripMenuItem.Click += new System.EventHandler(this.rikiuotToolStripMenuItem_Click);
            // 
            // salintToolStripMenuItem
            // 
            this.salintToolStripMenuItem.Name = "salintToolStripMenuItem";
            this.salintToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.salintToolStripMenuItem.Text = "Salint";
            this.salintToolStripMenuItem.Click += new System.EventHandler(this.salintToolStripMenuItem_Click);
            // 
            // papildytiToolStripMenuItem
            // 
            this.papildytiToolStripMenuItem.Name = "papildytiToolStripMenuItem";
            this.papildytiToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.papildytiToolStripMenuItem.Text = "Papildyti";
            this.papildytiToolStripMenuItem.Click += new System.EventHandler(this.papildytiToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox1.Location = new System.Drawing.Point(12, 377);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(12, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Amzius";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(9, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kiekis";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox2.Location = new System.Drawing.Point(12, 421);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(9, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(12, 27);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(1013, 319);
            this.rezultatai.TabIndex = 7;
            this.rezultatai.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 490);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaiciavimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem atidarytiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kurSaugotiTxtToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rikiuotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem papildytiToolStripMenuItem;
    }
}

