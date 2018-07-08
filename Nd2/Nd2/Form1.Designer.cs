namespace Nd2
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
            this.Įvesti = new System.Windows.Forms.Button();
            this.Spausdinti = new System.Windows.Forms.Button();
            this.Skaičiuoti = new System.Windows.Forms.Button();
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.Rasti = new System.Windows.Forms.Button();
            this.Baigti = new System.Windows.Forms.Button();
            this.Vertinimai = new System.Windows.Forms.ComboBox();
            this.Rezultatas = new System.Windows.Forms.Label();
            this.pavardeVardas = new System.Windows.Forms.Label();
            this.pavardeVrd = new System.Windows.Forms.TextBox();
            this.Atgal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Įvesti
            // 
            this.Įvesti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Įvesti.Location = new System.Drawing.Point(469, 32);
            this.Įvesti.Name = "Įvesti";
            this.Įvesti.Size = new System.Drawing.Size(139, 36);
            this.Įvesti.TabIndex = 0;
            this.Įvesti.Text = "Įvesti";
            this.Įvesti.UseVisualStyleBackColor = true;
            this.Įvesti.Click += new System.EventHandler(this.Įvesti_Click);
            // 
            // Spausdinti
            // 
            this.Spausdinti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Spausdinti.Location = new System.Drawing.Point(469, 74);
            this.Spausdinti.Name = "Spausdinti";
            this.Spausdinti.Size = new System.Drawing.Size(139, 38);
            this.Spausdinti.TabIndex = 1;
            this.Spausdinti.Text = "Spausdinti";
            this.Spausdinti.UseVisualStyleBackColor = true;
            this.Spausdinti.Click += new System.EventHandler(this.Spausdinti_Click);
            // 
            // Skaičiuoti
            // 
            this.Skaičiuoti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Skaičiuoti.Location = new System.Drawing.Point(469, 154);
            this.Skaičiuoti.Name = "Skaičiuoti";
            this.Skaičiuoti.Size = new System.Drawing.Size(139, 37);
            this.Skaičiuoti.TabIndex = 2;
            this.Skaičiuoti.Text = "Skaičiuoti";
            this.Skaičiuoti.UseVisualStyleBackColor = true;
            this.Skaičiuoti.Click += new System.EventHandler(this.Skaičiuoti_Click);
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(34, 32);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(412, 266);
            this.rezultatai.TabIndex = 3;
            this.rezultatai.Text = "";
            // 
            // Rasti
            // 
            this.Rasti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Rasti.Location = new System.Drawing.Point(469, 266);
            this.Rasti.Name = "Rasti";
            this.Rasti.Size = new System.Drawing.Size(139, 40);
            this.Rasti.TabIndex = 4;
            this.Rasti.Text = "Rasti";
            this.Rasti.UseVisualStyleBackColor = true;
            this.Rasti.Click += new System.EventHandler(this.Rasti_Click);
            // 
            // Baigti
            // 
            this.Baigti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Baigti.Location = new System.Drawing.Point(469, 358);
            this.Baigti.Name = "Baigti";
            this.Baigti.Size = new System.Drawing.Size(139, 37);
            this.Baigti.TabIndex = 5;
            this.Baigti.Text = "Baigti";
            this.Baigti.UseVisualStyleBackColor = true;
            this.Baigti.Click += new System.EventHandler(this.Baigti_Click);
            // 
            // Vertinimai
            // 
            this.Vertinimai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Vertinimai.FormattingEnabled = true;
            this.Vertinimai.Location = new System.Drawing.Point(469, 118);
            this.Vertinimai.Name = "Vertinimai";
            this.Vertinimai.Size = new System.Drawing.Size(192, 30);
            this.Vertinimai.TabIndex = 6;
            this.Vertinimai.Text = "Pasirinkite pažymį";
            // 
            // Rezultatas
            // 
            this.Rezultatas.AutoSize = true;
            this.Rezultatas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Rezultatas.ForeColor = System.Drawing.Color.Blue;
            this.Rezultatas.Location = new System.Drawing.Point(465, 217);
            this.Rezultatas.Name = "Rezultatas";
            this.Rezultatas.Size = new System.Drawing.Size(184, 19);
            this.Rezultatas.TabIndex = 7;
            this.Rezultatas.Text = "Čia bus parodyti rezultatai";
            // 
            // pavardeVardas
            // 
            this.pavardeVardas.AutoSize = true;
            this.pavardeVardas.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pavardeVardas.Location = new System.Drawing.Point(30, 312);
            this.pavardeVardas.Name = "pavardeVardas";
            this.pavardeVardas.Size = new System.Drawing.Size(169, 24);
            this.pavardeVardas.TabIndex = 8;
            this.pavardeVardas.Text = "Pavardė ir vardas";
            // 
            // pavardeVrd
            // 
            this.pavardeVrd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pavardeVrd.Location = new System.Drawing.Point(34, 351);
            this.pavardeVrd.Name = "pavardeVrd";
            this.pavardeVrd.Size = new System.Drawing.Size(355, 26);
            this.pavardeVrd.TabIndex = 9;
            this.pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";
            // 
            // Atgal
            // 
            this.Atgal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Atgal.Location = new System.Drawing.Point(469, 312);
            this.Atgal.Name = "Atgal";
            this.Atgal.Size = new System.Drawing.Size(139, 40);
            this.Atgal.TabIndex = 10;
            this.Atgal.Text = "Atgal";
            this.Atgal.UseVisualStyleBackColor = true;
            this.Atgal.Click += new System.EventHandler(this.Atgal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 445);
            this.Controls.Add(this.Atgal);
            this.Controls.Add(this.pavardeVrd);
            this.Controls.Add(this.pavardeVardas);
            this.Controls.Add(this.Rezultatas);
            this.Controls.Add(this.Vertinimai);
            this.Controls.Add(this.Baigti);
            this.Controls.Add(this.Rasti);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.Skaičiuoti);
            this.Controls.Add(this.Spausdinti);
            this.Controls.Add(this.Įvesti);
            this.Name = "Form1";
            this.Text = "                                                                                 " +
    "      Studentai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Įvesti;
        private System.Windows.Forms.Button Spausdinti;
        private System.Windows.Forms.Button Skaičiuoti;
        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.Button Rasti;
        private System.Windows.Forms.Button Baigti;
        private System.Windows.Forms.ComboBox Vertinimai;
        private System.Windows.Forms.Label Rezultatas;
        private System.Windows.Forms.Label pavardeVardas;
        private System.Windows.Forms.TextBox pavardeVrd;
        private System.Windows.Forms.Button Atgal;
    }
}

