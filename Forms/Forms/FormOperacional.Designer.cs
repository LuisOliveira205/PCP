namespace Forms
{
    partial class FormOperacional
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
            label2 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            comboBox1 = new ComboBox();
            richTextBox2 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(210, 53);
            label1.Name = "label1";
            label1.Size = new Size(249, 32);
            label1.TabIndex = 0;
            label1.Text = "Modúlo Operacional";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 111);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome da Tarefa";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(45, 129);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(100, 23);
            maskedTextBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 177);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 3;
            label3.Text = "Responsável";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(45, 195);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(192, 111);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 5;
            label4.Text = "Descrição da Tarefa";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(200, 129);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(100, 96);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(473, 111);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 7;
            label5.Text = "Prazo para Entrega";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(343, 111);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 8;
            label6.Text = "Observações";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(473, 129);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(473, 177);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 10;
            label7.Text = "Status";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(473, 195);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 11;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(343, 129);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(100, 96);
            richTextBox2.TabIndex = 12;
            richTextBox2.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(358, 267);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 13;
            button1.Text = "Finalizar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(210, 267);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 14;
            button2.Text = "Voltar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormOperacional
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 351);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox2);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(richTextBox1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(maskedTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormOperacional";
            Text = "FormOperacional";
            Load += FormOperacional_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MaskedTextBox maskedTextBox1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private RichTextBox richTextBox1;
        private Label label5;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private ComboBox comboBox1;
        private RichTextBox richTextBox2;
        private Button button1;
        private Button button2;
    }
}