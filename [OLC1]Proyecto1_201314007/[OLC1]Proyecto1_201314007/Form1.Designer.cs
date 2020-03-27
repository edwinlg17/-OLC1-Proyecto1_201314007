namespace _OLC1_Proyecto1_201314007
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miNuePes = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbri = new System.Windows.Forms.ToolStripMenuItem();
            this.miGua = new System.Windows.Forms.ToolStripMenuItem();
            this.miGuaCom = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAna = new System.Windows.Forms.ToolStripMenuItem();
            this.miGenAut = new System.Windows.Forms.ToolStripMenuItem();
            this.miRep = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tcPes = new System.Windows.Forms.TabControl();
            this.tpPes = new System.Windows.Forms.TabPage();
            this.rtEnt = new System.Windows.Forms.RichTextBox();
            this.rtCon = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbIma = new System.Windows.Forms.PictureBox();
            this.tvDir = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tcPes.SuspendLayout();
            this.tpPes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIma)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.analisisToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNuePes,
            this.miAbri,
            this.miGua,
            this.miGuaCom});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // miNuePes
            // 
            this.miNuePes.Name = "miNuePes";
            this.miNuePes.Size = new System.Drawing.Size(180, 22);
            this.miNuePes.Text = "Nueva Pestaña";
            this.miNuePes.Click += new System.EventHandler(this.miNuePes_Click);
            // 
            // miAbri
            // 
            this.miAbri.Name = "miAbri";
            this.miAbri.Size = new System.Drawing.Size(180, 22);
            this.miAbri.Text = "Abrir";
            this.miAbri.Click += new System.EventHandler(this.miAbri_Click);
            // 
            // miGua
            // 
            this.miGua.Name = "miGua";
            this.miGua.Size = new System.Drawing.Size(180, 22);
            this.miGua.Text = "Guardar";
            this.miGua.Click += new System.EventHandler(this.miGua_Click);
            // 
            // miGuaCom
            // 
            this.miGuaCom.Name = "miGuaCom";
            this.miGuaCom.Size = new System.Drawing.Size(180, 22);
            this.miGuaCom.Text = "Guardar Como";
            this.miGuaCom.Click += new System.EventHandler(this.miGuaCom_Click);
            // 
            // analisisToolStripMenuItem
            // 
            this.analisisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAna,
            this.miGenAut,
            this.miRep});
            this.analisisToolStripMenuItem.Name = "analisisToolStripMenuItem";
            this.analisisToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.analisisToolStripMenuItem.Text = "Analisis";
            // 
            // miAna
            // 
            this.miAna.Name = "miAna";
            this.miAna.Size = new System.Drawing.Size(180, 22);
            this.miAna.Text = "Analizar";
            this.miAna.Click += new System.EventHandler(this.miAna_Click);
            // 
            // miGenAut
            // 
            this.miGenAut.Name = "miGenAut";
            this.miGenAut.Size = new System.Drawing.Size(180, 22);
            this.miGenAut.Text = "Generar Automatas";
            this.miGenAut.Click += new System.EventHandler(this.miGenAut_Click);
            // 
            // miRep
            // 
            this.miRep.Name = "miRep";
            this.miRep.Size = new System.Drawing.Size(180, 22);
            this.miRep.Text = "Generar Reporte";
            this.miRep.Click += new System.EventHandler(this.miRep_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tcPes);
            this.panel1.Controls.Add(this.rtCon);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 561);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Consola";
            // 
            // tcPes
            // 
            this.tcPes.Controls.Add(this.tpPes);
            this.tcPes.Location = new System.Drawing.Point(3, 4);
            this.tcPes.Name = "tcPes";
            this.tcPes.SelectedIndex = 0;
            this.tcPes.Size = new System.Drawing.Size(411, 407);
            this.tcPes.TabIndex = 3;
            // 
            // tpPes
            // 
            this.tpPes.Controls.Add(this.rtEnt);
            this.tpPes.Location = new System.Drawing.Point(4, 22);
            this.tpPes.Name = "tpPes";
            this.tpPes.Padding = new System.Windows.Forms.Padding(3);
            this.tpPes.Size = new System.Drawing.Size(403, 381);
            this.tpPes.TabIndex = 0;
            this.tpPes.Text = "Pestaña 1";
            this.tpPes.UseVisualStyleBackColor = true;
            // 
            // rtEnt
            // 
            this.rtEnt.AcceptsTab = true;
            this.rtEnt.Location = new System.Drawing.Point(6, 6);
            this.rtEnt.Name = "rtEnt";
            this.rtEnt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtEnt.Size = new System.Drawing.Size(391, 369);
            this.rtEnt.TabIndex = 0;
            this.rtEnt.Text = "";
            // 
            // rtCon
            // 
            this.rtCon.Location = new System.Drawing.Point(3, 433);
            this.rtCon.Name = "rtCon";
            this.rtCon.Size = new System.Drawing.Size(408, 125);
            this.rtCon.TabIndex = 2;
            this.rtCon.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pbIma);
            this.panel2.Controls.Add(this.tvDir);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(432, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 561);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Grafico";
            // 
            // pbIma
            // 
            this.pbIma.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbIma.Location = new System.Drawing.Point(4, 174);
            this.pbIma.Name = "pbIma";
            this.pbIma.Size = new System.Drawing.Size(449, 384);
            this.pbIma.TabIndex = 2;
            this.pbIma.TabStop = false;
            // 
            // tvDir
            // 
            this.tvDir.Location = new System.Drawing.Point(4, 20);
            this.tvDir.Name = "tvDir";
            this.tvDir.Size = new System.Drawing.Size(449, 135);
            this.tvDir.TabIndex = 1;
            this.tvDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDir_AfterSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Archivos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tcPes.ResumeLayout(false);
            this.tpPes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAbri;
        private System.Windows.Forms.ToolStripMenuItem miGua;
        private System.Windows.Forms.ToolStripMenuItem miGuaCom;
        private System.Windows.Forms.ToolStripMenuItem miNuePes;
        private System.Windows.Forms.ToolStripMenuItem analisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAna;
        private System.Windows.Forms.ToolStripMenuItem miGenAut;
        private System.Windows.Forms.ToolStripMenuItem miRep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtCon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tcPes;
        private System.Windows.Forms.TabPage tpPes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtEnt;
        private System.Windows.Forms.TreeView tvDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbIma;
    }
}

