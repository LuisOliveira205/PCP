namespace PCP.Servico
{
    partial class Menu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEstrategico = new System.Windows.Forms.Button();
            this.btnTatico = new System.Windows.Forms.Button();
            this.btnOperacional = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEstrategico
            // 
            this.btnEstrategico.Location = new System.Drawing.Point(20, 50);
            this.btnEstrategico.Name = "btnEstrategico";
            this.btnEstrategico.Size = new System.Drawing.Size(100, 40);
            this.btnEstrategico.TabIndex = 0;
            this.btnEstrategico.Text = "Estratégico";
            // 
            // btnTatico
            // 
            this.btnTatico.Location = new System.Drawing.Point(140, 50);
            this.btnTatico.Name = "btnTatico";
            this.btnTatico.Size = new System.Drawing.Size(100, 40);
            this.btnTatico.TabIndex = 1;
            this.btnTatico.Text = "Tático";
            // 
            // btnOperacional
            // 
            this.btnOperacional.Location = new System.Drawing.Point(260, 50);
            this.btnOperacional.Name = "btnOperacional";
            this.btnOperacional.Size = new System.Drawing.Size(100, 40);
            this.btnOperacional.TabIndex = 2;
            this.btnOperacional.Text = "Operacional";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(140, 120);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(100, 30);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            // 
            // Menu
            // 
            this.ClientSize = new System.Drawing.Size(945, 336);
            this.Controls.Add(this.btnEstrategico);
            this.Controls.Add(this.btnTatico);
            this.Controls.Add(this.btnOperacional);
            this.Controls.Add(this.btnSair);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal - PCP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

