using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace Forms
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void textNome_Text(object sender, EventArgs e)
        {

        }

        private void textEmail_Text(object sender, EventArgs e)
        {

        }

        private void textSenha_Text(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textCpf_Text(object sender, EventArgs e)
        {

        }

        private void textSalario_Text(object sender, EventArgs e)
        {

        }

        private void textExperiencia_Text(object sender, EventArgs e)
        {

        }
    }
}
