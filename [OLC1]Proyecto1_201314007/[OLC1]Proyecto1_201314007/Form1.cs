using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201314007
{
    public partial class Form1 : Form
    {
        /////////////////////////// ATRIBUTOS
        ArrayList ruts = new ArrayList();

        /////////////////////////// CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();
            ruts.Add("");
        }

        /////////////////////////// METODOS
        private void tvDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label2.Text = tvDir.SelectedNode.FullPath;
        }

        //Menu Analizar
        private void miAna_Click(object sender, EventArgs e)
        {
            String tex = tcPes.SelectedTab.Controls[0].Text;

            Console.WriteLine("//////////////////////// Analisis Lexico");
            AnalizadorLexico a = new AnalizadorLexico();
            a.analizar(tex);
            ArrayList lisTok = a.lisTok;

            foreach (Token t in lisTok)
            {
                Console.WriteLine("ID:" + t.ide + " TOK:" + t.tok + " LEX:" + t.lex + " FIL:" + t.fil + " COL:" + t.col);
            }



            //TreeNode n = new TreeNode("Directorio 1");

            //TreeNode ele = new TreeNode("elemento");
            //n.Nodes.Add("Elemento 1");
            //n.Nodes.Add("Elemento 2");
            //n.Nodes.Add("Elemento 3");
            //n.Nodes.Add("Elemento 4");
            //n.Nodes.Add("Elemento 5");

            //tvDir.Nodes.Add(n);

            //n = new TreeNode("Directorio 2");
            //n.Nodes.Add("Elemento 1");
            //n.Nodes.Add("Elemento 2");
            //n.Nodes.Add("Elemento 3");
            //n.Nodes.Add("Elemento 4");
            //n.Nodes.Add("Elemento 5");

            //tvDir.Nodes.Add(n);
        }

        private void miGenAut_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ruts[tcPes.SelectedIndex]);
            //Console.WriteLine(tcPes.SelectedIndex);
        }

        //Menu Archivo
        private void miNuePes_Click(object sender, EventArgs e)
        {
            crePes();
            ruts.Add("");
        }

        private void miAbri_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos ER|*.er"; // filtro para el open file dialog
            ofd.Title = "Abrir Archivo"; // titulo para el open file dialog
            if (ofd.ShowDialog() == DialogResult.OK) // verifico que el open file dialogo no este vacio
            {
                // obtengo el texto
                string text = System.IO.File.ReadAllText(@ofd.FileName);
                // creo la pestaña
                crePes();
                // obtengo el control
                Control temp = tcPes.SelectedTab.Controls[0];
                // asigno el texto al control
                temp.Text = text;
                tcPes.SelectedTab.Text = ofd.SafeFileName;
                ruts.Add(ofd.FileName);
            }
        }

        private void miGua_Click(object sender, EventArgs e)
        {
            if (ruts[tcPes.SelectedIndex].Equals(""))
            {
                guaArc();
            }
            else 
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter((String)ruts[tcPes.SelectedIndex]);
                file.WriteLine(tcPes.SelectedTab.Controls[0].Text);
                file.Close();
            }
        }

        private void miGuaCom_Click(object sender, EventArgs e)
        {
            guaArc();
        }

        private void crePes()
        {
            //creo la tab page y el rich text box
            this.tpPes = new System.Windows.Forms.TabPage();
            this.rtEnt = new System.Windows.Forms.RichTextBox();

            //configuro el rich text box
            this.rtEnt.AcceptsTab = true;
            this.rtEnt.Location = new System.Drawing.Point(6, 6);
            this.rtEnt.Name = "rtEnt";
            this.rtEnt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtEnt.Size = new System.Drawing.Size(391, 369);
            this.rtEnt.TabIndex = 0;
            this.rtEnt.Text = "";

            //configuro la tab page
            int ind = tcPes.TabCount + 1;
            this.tpPes.Controls.Add(this.rtEnt);
            this.tpPes.Location = new System.Drawing.Point(4, 22);
            this.tpPes.Name = "tpPes";
            this.tpPes.Padding = new System.Windows.Forms.Padding(3);
            this.tpPes.Size = new System.Drawing.Size(403, 381);
            this.tpPes.TabIndex = ind;
            this.tpPes.Text = "Pestaña " + ind;
            this.tpPes.UseVisualStyleBackColor = true;

            //agrego el control y lo selecciono
            this.tcPes.Controls.Add(this.tpPes);
            this.tcPes.SelectedTab = this.tcPes.TabPages[ind - 1];
            this.rtEnt.Focus();
        }
        
        private void guaArc() 
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Archivos (*.er)|*.er"; //|All files (*.*)|*.*"
            sfd.DefaultExt = "er";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter(sfd.FileName);
                file.WriteLine(tcPes.SelectedTab.Controls[0].Text);
                ruts[tcPes.SelectedIndex] = sfd.FileName;
                file.Close();
            }
        }
    }
}
