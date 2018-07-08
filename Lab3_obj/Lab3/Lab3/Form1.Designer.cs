namespace Lab3
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.valdymasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvesti = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdinti = new System.Windows.Forms.ToolStripMenuItem();
            this.uždaryt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daugiausiaiHP = new System.Windows.Forms.ToolStripMenuItem();
            this.atrinktRases = new System.Windows.Forms.ToolStripMenuItem();
            this.rastiGeriausia = new System.Windows.Forms.ToolStripMenuItem();
            this.atrinktiHerojusPagalDuom = new System.Windows.Forms.ToolStripMenuItem();
            this.rikiuot = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.HP = new System.Windows.Forms.Label();
            this.DEF = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rezult = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valdymasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // valdymasToolStripMenuItem
            // 
            this.valdymasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvesti,
            this.spausdinti,
            this.uždaryt,
            this.toolStripSeparator1});
            this.valdymasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.valdymasToolStripMenuItem.Name = "valdymasToolStripMenuItem";
            this.valdymasToolStripMenuItem.Size = new System.Drawing.Size(94, 25);
            this.valdymasToolStripMenuItem.Text = "Vykdymas";
            // 
            // įvesti
            // 
            this.įvesti.Name = "įvesti";
            this.įvesti.Size = new System.Drawing.Size(153, 26);
            this.įvesti.Text = "Įvesti";
            this.įvesti.Click += new System.EventHandler(this.įvesti_Click);
            // 
            // spausdinti
            // 
            this.spausdinti.Name = "spausdinti";
            this.spausdinti.Size = new System.Drawing.Size(153, 26);
            this.spausdinti.Text = "Spausdinti";
            this.spausdinti.Click += new System.EventHandler(this.spausdinti_Click);
            // 
            // uždaryt
            // 
            this.uždaryt.Name = "uždaryt";
            this.uždaryt.Size = new System.Drawing.Size(153, 26);
            this.uždaryt.Text = "Uždaryti";
            this.uždaryt.Click += new System.EventHandler(this.uždaryt_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daugiausiaiHP,
            this.atrinktRases,
            this.rastiGeriausia,
            this.atrinktiHerojusPagalDuom,
            this.rikiuot});
            this.skaičiavimaiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // daugiausiaiHP
            // 
            this.daugiausiaiHP.Name = "daugiausiaiHP";
            this.daugiausiaiHP.Size = new System.Drawing.Size(274, 26);
            this.daugiausiaiHP.Text = "Daugiausiai HP";
            this.daugiausiaiHP.Click += new System.EventHandler(this.daugiausiaiHP_Click);
            // 
            // atrinktRases
            // 
            this.atrinktRases.Name = "atrinktRases";
            this.atrinktRases.Size = new System.Drawing.Size(274, 26);
            this.atrinktRases.Text = "Atrinkt Rases";
            this.atrinktRases.Click += new System.EventHandler(this.atrinktRases_Click);
            // 
            // rastiGeriausia
            // 
            this.rastiGeriausia.Name = "rastiGeriausia";
            this.rastiGeriausia.Size = new System.Drawing.Size(274, 26);
            this.rastiGeriausia.Text = "Rasti geriausia";
            this.rastiGeriausia.Click += new System.EventHandler(this.rastiGeriausia_Click);
            // 
            // atrinktiHerojusPagalDuom
            // 
            this.atrinktiHerojusPagalDuom.Name = "atrinktiHerojusPagalDuom";
            this.atrinktiHerojusPagalDuom.Size = new System.Drawing.Size(274, 26);
            this.atrinktiHerojusPagalDuom.Text = "Atrinkti herojus pagal duom";
            this.atrinktiHerojusPagalDuom.Click += new System.EventHandler(this.atrinktiHerojusPagalDuom_Click);
            // 
            // rikiuot
            // 
            this.rikiuot.Name = "rikiuot";
            this.rikiuot.Size = new System.Drawing.Size(274, 26);
            this.rikiuot.Text = "Rikiuoti";
            this.rikiuot.Click += new System.EventHandler(this.rikiuot_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox1.Location = new System.Drawing.Point(55, 336);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox2.Location = new System.Drawing.Point(55, 368);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 2;
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.HP.Location = new System.Drawing.Point(12, 336);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(30, 19);
            this.HP.TabIndex = 3;
            this.HP.Text = "HP";
            // 
            // DEF
            // 
            this.DEF.AutoSize = true;
            this.DEF.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.DEF.Location = new System.Drawing.Point(12, 362);
            this.DEF.Name = "DEF";
            this.DEF.Size = new System.Drawing.Size(40, 19);
            this.DEF.TabIndex = 4;
            this.DEF.Text = "DEF";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox3.Location = new System.Drawing.Point(219, 335);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 26);
            this.textBox3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(169, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rase";
            // 
            // rezult
            // 
            this.rezult.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezult.Location = new System.Drawing.Point(13, 28);
            this.rezult.Name = "rezult";
            this.rezult.Size = new System.Drawing.Size(1100, 301);
            this.rezult.TabIndex = 7;
            this.rezult.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 25);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 394);
            this.Controls.Add(this.rezult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.DEF);
            this.Controls.Add(this.HP);
            this.Controls.Add(this.textBox2);
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
        private System.Windows.Forms.ToolStripMenuItem valdymasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvesti;
        private System.Windows.Forms.ToolStripMenuItem uždaryt;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem spausdinti;
        private System.Windows.Forms.ToolStripMenuItem daugiausiaiHP;
        private System.Windows.Forms.ToolStripMenuItem atrinktRases;
        private System.Windows.Forms.ToolStripMenuItem atrinktiHerojusPagalDuom;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label HP;
        private System.Windows.Forms.Label DEF;
        private System.Windows.Forms.ToolStripMenuItem rikiuot;
        private System.Windows.Forms.ToolStripMenuItem rastiGeriausia;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rezult;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

