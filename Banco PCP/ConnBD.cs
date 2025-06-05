using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    string query = "INSERT INTO estrategicos (objetivo_es) VALUES (@objetivo_es)";
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
                    string query = "INSERT INTO estrategicos (estrategia_es) VALUES (@estrategia_es)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estrategia_es", estrategia);
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
                    string query = "INSERT INTO estrategicos (equipamentos_es, trabalhadores_es, materiais_es) VALUES (@equipamentos_es, @trabalhadores_es, @materiais_es)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@equipamentos_es", equipamentos);
                        cmd.Parameters.AddWithValue("@trabalhadores_es", trabalhadores);
                        cmd.Parameters.AddWithValue("@materiais_es", materiais);
                        cmd.ExecuteNonQuery();
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

        public bool cadEstrategico(string email, string senha, string cpf)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM estrategicos WHERE email_es = @email_es";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email_es", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("Email já cadastrado.");
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO estrategicos (email_es, senha_es, cpf_es) VALUES (@email_es, @senha_es, @cpf_es)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_es", email);
                        cmd.Parameters.AddWithValue("@senha_es", senha);
                        cmd.Parameters.AddWithValue("@cpf_es", cpf);
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

        public bool logEstrategico(string email, string senha)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM estrategicos WHERE email_es = @email_es AND senha_es = @senha_es";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_es", email);
                        cmd.Parameters.AddWithValue("@senha_es", senha);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("Login bem-sucedido. Bem-vindo!");
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
