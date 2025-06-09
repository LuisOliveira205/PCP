using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCP.Servico
{

    public partial class Menu : Form
    {
        private Button btnEstrategico;
        private Button btnTatico;
        private Button btnOperacional;
        private Button btnSair;

        public Menu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Menu Principal - PCP";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            btnEstrategico = new Button();
            btnEstrategico.Text = "Estratégico";
            btnEstrategico.Size = new Size(100, 40);
            btnEstrategico.Location = new Point(20, 50);
            btnEstrategico.Click += BtnEstrategico_Click;
            this.Controls.Add(btnEstrategico);

            btnTatico = new Button();
            btnTatico.Text = "Tático";
            btnTatico.Size = new Size(100, 40);
            btnTatico.Location = new Point(140, 50);
            btnTatico.Click += BtnTatico_Click;
            this.Controls.Add(btnTatico);

            btnOperacional = new Button();
            btnOperacional.Text = "Operacional";
            btnOperacional.Size = new Size(100, 40);
            btnOperacional.Location = new Point(260, 50);
            btnOperacional.Click += BtnOperacional_Click;
            this.Controls.Add(btnOperacional);

            btnSair = new Button();
            btnSair.Text = "Sair";
            btnSair.Size = new Size(100, 30);
            btnSair.Location = new Point(140, 120);
            btnSair.Click += BtnSair_Click;
            this.Controls.Add(btnSair);
        }

        private void BtnEstrategico_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new FormEstrategico())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void BtnTatico_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new FormTatico())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void BtnOperacional_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new FormOperacional())
            {
                form.ShowDialog();
            }
            this.Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


    public class FormEstrategico : Form
    {
        public FormEstrategico()
        {
            this.Text = "Formulário Estratégico";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label()
            {
                Text = "Bem-vindo ao módulo Estratégico",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            this.Controls.Add(lbl);
        }
    }


    public class FormTatico : Form
    {
        public FormTatico()
        {
            this.Text = "Formulário Tático";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label()
            {
                Text = "Bem-vindo ao módulo Tático",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            this.Controls.Add(lbl);
        }
    }


    public class FormOperacional : Form
    {
        public FormOperacional()
        {
            this.Text = "Formulário Operacional";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label()
            {
                Text = "Bem-vindo ao módulo Operacional",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            this.Controls.Add(lbl);
        }
    }
}
