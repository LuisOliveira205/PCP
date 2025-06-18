using MySql.Data.MySqlClient;

private void Cadastrar_Click(object sender, EventArgs e)
{
    try
    {
        MySqlConnection conn = Conexao.Abrir();

        string query = "INSERT INTO estrategicos (nome_es, email_es, senha_es, cpf_es, salario_es, experiencia_es, nascimento_es, contratacao_es) " +
                       "VALUES (@nome, @email, @senha, @cpf, @salario, @experiencia, @nascimento, @contratacao)";

        MySqlCommand cmd = new MySqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
        cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
        cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);
        cmd.Parameters.AddWithValue("@salario", Convert.ToDecimal(txtSalario.Text));
        cmd.Parameters.AddWithValue("@experiencia", Convert.ToInt32(txtExperiencia.Text));
        cmd.Parameters.AddWithValue("@nascimento", dtpNascimento.Value); // dateTimePicker
        cmd.Parameters.AddWithValue("@contratacao", dtpContratacao.Value);

        cmd.ExecuteNonQuery();
        MessageBox.Show("Usuário cadastrado com sucesso!");
    }
    catch (Exception ex)
    {
        MessageBox.Show("Erro ao cadastrar: " + ex.Message);
    }
    
    
        
    
}

