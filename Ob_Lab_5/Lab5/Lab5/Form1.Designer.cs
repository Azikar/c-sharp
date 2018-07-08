namespace Lab5
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
            this.duomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ivestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darbasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrinktPasirinktusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrinktNepasirinktusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentasSuDaugiausiaiModuliuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezult = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duomToolStripMenuItem,
            this.darbasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // duomToolStripMenuItem
            // 
            this.duomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ivestiToolStripMenuItem,
            this.baigtiToolStripMenuItem,
            this.spaustToolStripMenuItem});
            this.duomToolStripMenuItem.Name = "duomToolStripMenuItem";
            this.duomToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.duomToolStripMenuItem.Text = "Duom";
            // 
            // ivestiToolStripMenuItem
            // 
            this.ivestiToolStripMenuItem.Name = "ivestiToolStripMenuItem";
            this.ivestiToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ivestiToolStripMenuItem.Text = "Ivesti";
            this.ivestiToolStripMenuItem.Click += new System.EventHandler(this.ivestiToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // spaustToolStripMenuItem
            // 
            this.spaustToolStripMenuItem.Name = "spaustToolStripMenuItem";
            this.spaustToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.spaustToolStripMenuItem.Text = "Spaust";
            this.spaustToolStripMenuItem.Click += new System.EventHandler(this.spaustToolStripMenuItem_Click);
            // 
            // darbasToolStripMenuItem
            // 
            this.darbasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atrinktPasirinktusToolStripMenuItem,
            this.atrinktNepasirinktusToolStripMenuItem,
            this.studentasSuDaugiausiaiModuliuToolStripMenuItem});
            this.darbasToolStripMenuItem.Name = "darbasToolStripMenuItem";
            this.darbasToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.darbasToolStripMenuItem.Text = "Darbas";
            // 
            // atrinktPasirinktusToolStripMenuItem
            // 
            this.atrinktPasirinktusToolStripMenuItem.Name = "atrinktPasirinktusToolStripMenuItem";
            this.atrinktPasirinktusToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.atrinktPasirinktusToolStripMenuItem.Text = "Atrinkt pasirinktus";
            this.atrinktPasirinktusToolStripMenuItem.Click += new System.EventHandler(this.atrinktPasirinktusToolStripMenuItem_Click);
            // 
            // atrinktNepasirinktusToolStripMenuItem
            // 
            this.atrinktNepasirinktusToolStripMenuItem.Name = "atrinktNepasirinktusToolStripMenuItem";
            this.atrinktNepasirinktusToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.atrinktNepasirinktusToolStripMenuItem.Text = "Atrinkt nepasirinktus";
            this.atrinktNepasirinktusToolStripMenuItem.Click += new System.EventHandler(this.atrinktNepasirinktusToolStripMenuItem_Click);
            // 
            // studentasSuDaugiausiaiModuliuToolStripMenuItem
            // 
            this.studentasSuDaugiausiaiModuliuToolStripMenuItem.Name = "studentasSuDaugiausiaiModuliuToolStripMenuItem";
            this.studentasSuDaugiausiaiModuliuToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.studentasSuDaugiausiaiModuliuToolStripMenuItem.Text = "Studentas su daugiausiai moduliu";
            this.studentasSuDaugiausiaiModuliuToolStripMenuItem.Click += new System.EventHandler(this.studentasSuDaugiausiaiModuliuToolStripMenuItem_Click);
            // 
            // rezult
            // 
            this.rezult.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezult.Location = new System.Drawing.Point(13, 43);
            this.rezult.Name = "rezult";
            this.rezult.Size = new System.Drawing.Size(856, 307);
            this.rezult.TabIndex = 1;
            this.rezult.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 376);
            this.Controls.Add(this.rezult);
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
        private System.Windows.Forms.ToolStripMenuItem duomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ivestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darbasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrinktPasirinktusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrinktNepasirinktusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentasSuDaugiausiaiModuliuToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rezult;
    }
}

