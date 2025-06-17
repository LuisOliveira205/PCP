using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEstratégico fe = new FormEstratégico();
            fe.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTático ft = new FormTático();
            ft.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormOperacional fo = new FormOperacional();
            fo.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 F1= new Form1();
            F1.Show();
            this.Hide();
        }
    }
}
