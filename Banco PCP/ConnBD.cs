using System;
using MySql.Data.MySqlClient;

namespace Banco_Arquivo
{
    internal class ConnBD
    {
        private static string conexao = "server=localhost;user=root;database=TOI;port=3306;password=root";

        public void bancoObjetivo(string objetivo)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string query = "insert into estrategicos (objetivo_es) values (@objetivo_es)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@objetivo_es", objetivo);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoEstrategia(string estrategia)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string query = "insert into estrategicos (estrategia_es) values (@estrategia_es)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@objetivo_es", estrategia);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoRecursos(string equipamentos, int trabalhadores, string materiais)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string query = "insert into estrategicos (equipamentos_es, trabalhadores_es, materiais_es) values (@equipamentos_es, @trabalhadores_es, @materiais_es)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@equipamentos_es", equipamentos);
                        cmd.Parameters.AddWithValue("@trabalhadores_es", trabalhadores);
                        cmd.Parameters.AddWithValue("@materiais_es", materiais);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoPortifolio(string portifolio)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO estrategicos (portifolio_es) VALUES (@portifolio_es)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@portifolio_es", portifolio);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoLocal(string local)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO estrategicos (local_es) VALUES (@local_es)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@local_es", local);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoRelacoes(string relacoes)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO estrategicos (relacoes_es) VALUES (@relacoes_es)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@relacoes_es", relacoes);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public bool Cadastrar(string nome, string email, string senha)
        {
            using (var conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";

                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("Email já cadastrado.");
                            return false;
                        }
                    }

                    string query = "INSERT INTO usuarios (nome, email, senha) VALUES (@Nome, @Email, @Senha)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Login(string email, string senha)
        {
            using (var conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM usuarios WHERE email = @Email AND senha = @Senha";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha); // ideal: comparar hash

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("Login bem-sucedido. Bem-vindo, " + reader["nome"]);
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Email ou senha inválidos.");
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
