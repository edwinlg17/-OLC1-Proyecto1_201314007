using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void btAgrPes_Click(object sender, EventArgs e)
        {
            this.tabPage1 = new System.Windows.Forms.TabPage();

            int num = tabControl1.TabCount + 1;

            this.rtEnt = new System.Windows.Forms.RichTextBox();
            this.rtEnt.Location = new System.Drawing.Point(0, 0);
            this.rtEnt.Name = "rtEnt";
            this.rtEnt.Size = new System.Drawing.Size(432, 373);
            this.rtEnt.TabIndex = 0;
            this.rtEnt.Text = "";

            this.tabPage1.Controls.Add(this.rtEnt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 282);
            this.tabPage1.TabIndex = num;
            this.tabPage1.Text = "Pestaña " + num;
            this.tabPage1.UseVisualStyleBackColor = true;

            int temp = tabControl1.TabCount;
            this.tabControl1.Controls.Add(this.tabPage1);

            tabControl1.SelectedTab = tabControl1.TabPages[temp];
        }

    }
}
