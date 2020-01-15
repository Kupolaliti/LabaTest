using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        { InitializeComponent(); }              
        
        int i = 1;
        private void newToolStripMenuItem_Click(object sender, EventArgs e) //File -> New
        {
            IsMdiContainer = true;
            Child newForm = new Child();
            newForm.MdiParent = this;
            newForm.Text = "Child " + i;
            i++;
            newForm.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) //File -> Close
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e) //File -> Close All
        {
            Form[] form = MdiChildren;
            foreach (Form f in form)
                f.Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e) //Window -> Cascade
        { this.LayoutMdi(MdiLayout.Cascade); }

        private void verticalTileToolStripMenuItem_Click(object sender, EventArgs e) //Window -> VT
        { this.LayoutMdi(MdiLayout.TileVertical); }

        private void horizontalTileToolStripMenuItem_Click(object sender, EventArgs e) //Window -> HT
        { this.LayoutMdi(MdiLayout.TileHorizontal); }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            IniFile ini = new IniFile("my.ini");
            try
            {
                ini.Write("height", Convert.ToString(Height));
                ini.Write("width", Convert.ToString(Width));
                ini.Write("opacity", Convert.ToString(Opacity));
                ini.Write("locX", Convert.ToString(Location.X));
                ini.Write("locY", Convert.ToString(Location.Y));
            }
            catch
            { }
        }
    }
}
