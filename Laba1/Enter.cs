using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Enter : Form
    {
        
        public Enter()
        {
            InitializeComponent();
        }

        int Prov;
        string Login, Password;
        private void Button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login = textBox1.Text;
                Password = textBox2.Text;
                Prov = DB.SQL_CONNECT(Login, Password);
                if (Prov == 0)
                {
                    Form1 help = new Form1();
                    help.Show();
                    Hide();
                }
                else label3.Text = "Некорректные данные!";
            }
            else
                label3.Text = "Введите данные!";
        }

        
    }
}
