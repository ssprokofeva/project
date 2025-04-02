using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            новая_выставка form2 = new новая_выставка();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Filtr filtr = new Filtr();
            filtr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
