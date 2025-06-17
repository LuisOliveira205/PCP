namespace Forms
{
    partial class FormTático
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label7 = new Label();
            comboBox2 = new ComboBox();
            label8 = new Label();
            comboBox3 = new ComboBox();
            label9 = new Label();
            richTextBox2 = new RichTextBox();
            label10 = new Label();
            textBox3 = new TextBox();
            label11 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(309, 26);
            label1.Name = "label1";
            label1.Size = new Size(179, 32);
            label1.TabIndex = 0;
            label1.Text = "Modúlo Tático";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 8.25F);
            textBox1.Location = new Point(12, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(113, 20);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 2;
            label2.Text = "Nome do Projeto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 224);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 3;
            label3.Text = "Objetivo";
            // 
            // button1
            // 
            button1.Location = new Point(413, 354);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Finalizar";
            button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(11, 242);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(100, 96);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 187);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 169);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 8;
            label4.Text = "Responsável";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(228, 111);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(228, 90);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 10;
            label5.Text = "Departamento";
            label5.Click += label5_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(228, 187);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(228, 169);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 12;
            label6.Text = "Data de Início";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(228, 280);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(228, 262);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 14;
            label7.Text = "Data de Término";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(514, 111);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(514, 93);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 16;
            label8.Text = "Status";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(514, 190);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(514, 169);
            label9.Name = "label9";
            label9.Size = new Size(61, 15);
            label9.TabIndex = 18;
            label9.Text = "Prioridade";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(514, 242);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(100, 96);
            richTextBox2.TabIndex = 19;
            richTextBox2.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(514, 224);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 20;
            label10.Text = "Descrição";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(657, 242);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(657, 224);
            label11.Name = "label11";
            label11.Size = new Size(93, 15);
            label11.TabIndex = 22;
            label11.Text = "Relacionamento";
            // 
            // button2
            // 
            button2.Location = new Point(274, 354);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 23;
            button2.Text = "Voltar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormTático
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(label11);
            Controls.Add(textBox3);
            Controls.Add(label10);
            Controls.Add(richTextBox2);
            Controls.Add(label9);
            Controls.Add(comboBox3);
            Controls.Add(label8);
            Controls.Add(comboBox2);
            Controls.Add(label7);
            Controls.Add(dateTimePicker2);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "FormTático";
            Text = "FormTático";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Button button1;
        private RichTextBox richTextBox1;
        private TextBox textBox2;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private DateTimePicker dateTimePicker2;
        private Label label7;
        private ComboBox comboBox2;
        private Label label8;
        private ComboBox comboBox3;
        private Label label9;
        private RichTextBox richTextBox2;
        private Label label10;
        private TextBox textBox3;
        private Label label11;
        private Button button2;
    }
}