﻿namespace lab2db
{
    partial class davikliai
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trinti = new System.Windows.Forms.Button();
            this.Pakeist = new System.Windows.Forms.Button();
            this.pridet = new System.Windows.Forms.Button();
            this.Nuskaityt = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Pavadinimas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ID";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 26;
            // 
            // trinti
            // 
            this.trinti.Location = new System.Drawing.Point(67, 216);
            this.trinti.Name = "trinti";
            this.trinti.Size = new System.Drawing.Size(75, 28);
            this.trinti.TabIndex = 25;
            this.trinti.Text = "trinti";
            this.trinti.UseVisualStyleBackColor = true;
            this.trinti.Click += new System.EventHandler(this.trinti_Click);
            // 
            // Pakeist
            // 
            this.Pakeist.Location = new System.Drawing.Point(67, 187);
            this.Pakeist.Name = "Pakeist";
            this.Pakeist.Size = new System.Drawing.Size(75, 28);
            this.Pakeist.TabIndex = 24;
            this.Pakeist.Text = "Pakeist";
            this.Pakeist.UseVisualStyleBackColor = true;
            this.Pakeist.Click += new System.EventHandler(this.Pakeist_Click);
            // 
            // pridet
            // 
            this.pridet.Location = new System.Drawing.Point(67, 158);
            this.pridet.Name = "pridet";
            this.pridet.Size = new System.Drawing.Size(75, 28);
            this.pridet.TabIndex = 23;
            this.pridet.Text = "pridet";
            this.pridet.UseVisualStyleBackColor = true;
            this.pridet.Click += new System.EventHandler(this.pridet_Click);
            // 
            // Nuskaityt
            // 
            this.Nuskaityt.Location = new System.Drawing.Point(67, 129);
            this.Nuskaityt.Name = "Nuskaityt";
            this.Nuskaityt.Size = new System.Drawing.Size(75, 28);
            this.Nuskaityt.TabIndex = 22;
            this.Nuskaityt.Text = "Nuskaityt";
            this.Nuskaityt.UseVisualStyleBackColor = true;
            this.Nuskaityt.Click += new System.EventHandler(this.Nuskaityt_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(196, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(245, 270);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Pavadinimas";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            // 
            // davikliai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 294);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trinti);
            this.Controls.Add(this.Pakeist);
            this.Controls.Add(this.pridet);
            this.Controls.Add(this.Nuskaityt);
            this.Controls.Add(this.dataGridView1);
            this.Name = "davikliai";
            this.Text = "davikliai";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.davikliai_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button trinti;
        private System.Windows.Forms.Button Pakeist;
        private System.Windows.Forms.Button pridet;
        private System.Windows.Forms.Button Nuskaityt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}