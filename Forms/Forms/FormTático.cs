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
    public partial class FormTático : Form
    {
        public FormTático()
        {
            InitializeComponent();
        }

        private void labelNomeProjeto(object sender, EventArgs e)
        {
            Label labelNomeProjeto = new Label();
            labelNomeProjeto.Text = "Nome do Projeto:";
            labelNomeProjeto.Location = new Point(20, 20);
            this.Controls.Add(labelNomeProjeto);

            TextBox nomeProjetoBox = new TextBox();
            nomeProjetoBox.Location = new Point(150, 20);
            nomeProjetoBox.Size = new Size(200, 20);
            this.Controls.Add(nomeProjetoBox);
        }

        private void labelResponsavel(object sender, EventArgs e)
        {
            Label labelResponsavel = new Label();
            labelResponsavel.Text = "Responsável:";
            labelResponsavel.Location = new Point(20, 60);
            this.Controls.Add(labelResponsavel);

            TextBox responsavelBox = new TextBox();
            responsavelBox.Location = new Point(150, 60);
            responsavelBox.Size = new Size(200, 20);
            this.Controls.Add(responsavelBox);
        }

        private void labelObjetivo_TextChanged(object sender, EventArgs e)
        {
            Label labelObjetivo = new Label();
            labelObjetivo.Text = "Objetivo Tático:";
            labelObjetivo.Location = new Point(20, 100);
            this.Controls.Add(labelObjetivo);

            RichTextBox objetivoBox = new RichTextBox();
            objetivoBox.Location = new Point(150, 100);
            objetivoBox.Size = new Size(300, 100);
            this.Controls.Add(objetivoBox);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
