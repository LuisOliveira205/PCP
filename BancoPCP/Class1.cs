using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BancoPCP
{
    public class ConnBD
    {
        private static string conexao = "server=localhost;user=root;database=TOI;port=3306;password=root";

        //ESTRATEGICO

        public void bancoObjetivo(string objetivo)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_es (objetivo_es) values (@objetivo_es)";
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
                    string query = "insert into funcao_es (estrategia_es) values (@estrategia_es)";
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

        public void bancoRecursos(string equipamentos, int trabalhadores)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_es (equipamentos_es, trabalhadores_es) values (@equipamentos_es, @trabalhadores_es)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@equipamentos_es", equipamentos);
                        cmd.Parameters.AddWithValue("@trabalhadores_es", trabalhadores);
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
                    string query = "insert into funcao_es (portifolio_es) values (@portifolio_es)";
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
                    string query = "insert into funcao_es (local_es) values (@local_es)";
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

        public bool cadEstrategico(string email, string senha, string cpf, int experiencia, decimal salario, string estado, string cidade, string rua, DateTime nascimento, DateTime contratacao)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "select count(*) from estrategicos where email_es = @email_es";
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

                    string insertQuery = "insert into estrategicos (email_es, senha_es, cpf_es, experiencia_es, salario_es, nascimento_es, contratacao_es) values (@email_es, @senha_es, @cpf_es, @experiencia_es, @salario_es, @nascimento_es, @contratacao_es)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_es", email);
                        cmd.Parameters.AddWithValue("@senha_es", senha);
                        cmd.Parameters.AddWithValue("@cpf_es", cpf);
                        cmd.Parameters.AddWithValue("@experiencia_es", experiencia);
                        cmd.Parameters.AddWithValue("@salario_es", salario);
                        cmd.Parameters.AddWithValue("@nascimento_es", nascimento);
                        cmd.Parameters.AddWithValue("@contratacao_es", contratacao);
                        cmd.ExecuteNonQuery();
                    }
                    string insertEnderecoQuery = "insert into endereço_estrategicos (estado_es, cidade_es, rua_es) values (@estado_es, @cidade_es, @rua_es)";
                    using (MySqlCommand cmdEnderecoEs = new MySqlCommand(insertEnderecoQuery, conn))
                    {
                        cmdEnderecoEs.Parameters.AddWithValue("@estado_es", estado);
                        cmdEnderecoEs.Parameters.AddWithValue("@cidade_es", cidade);
                        cmdEnderecoEs.Parameters.AddWithValue("@rua_es", rua);
                        cmdEnderecoEs.ExecuteNonQuery();
                        return true;
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
                    string query = "select * from estrategicos where email_es = @email_es and senha_es = @senha_es";
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

        //TATICO

        public void bancoPlano(string plano)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_ta (plano_ta) values (@plano_ta)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plano_ta", plano);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoLotesCronograma(string lotes, string cronograma)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_ta (lotes_ta, cronograma_ta) values (@lotes_ta, @cronograma_ta)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@lotes_ta", lotes);
                        cmd.Parameters.AddWithValue("@cronograma_ta", cronograma);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoCapacidade(string ajuste)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_ta (ajuste_ta) values (@ajuste_ta)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ajuste_ta", ajuste);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoDesvios(string desvios)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_ta (desvios_ta) values (@desvios_ta)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@desvios_ta", desvios);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public bool cadTatico(string email, string senha, string cpf, int experiencia, decimal salario, string estado, string cidade, string rua, DateTime nascimento, DateTime contratacao)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "select count(*) from taticos where email_ta = @email_ta";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email_ta", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("Email já cadastrado.");
                            return false;
                        }
                    }

                    string insertQuery = "insert into taticos (email_ta, senha_ta, cpf_ta, experiencia_ta, salario_ta, nascimento_ta, contratacao_ta) values (@email_ta, @senha_ta, @cpf_ta, @experiencia_ta, @salario_ta, @nascimento_ta, @contratacao_ta)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_ta", email);
                        cmd.Parameters.AddWithValue("@senha_ta", senha);
                        cmd.Parameters.AddWithValue("@cpf_ta", cpf);
                        cmd.Parameters.AddWithValue("@experiencia_ta", experiencia);
                        cmd.Parameters.AddWithValue("@salario_ta", salario);
                        cmd.Parameters.AddWithValue("@nascimento_ta", nascimento);
                        cmd.Parameters.AddWithValue("@contratacao_ta", contratacao);

                        int result = cmd.ExecuteNonQuery();
                    }
                    string insertTaticoQuery = "insert into endereço_taticos (estado_ta, cidade_ta, rua_ta, cod_ta) values (@estado_ta, @cidade_ta, @rua_ta, @cod_ta)";
                    using (MySqlCommand cmdEnderecoTa = new MySqlCommand(insertTaticoQuery, conn))
                    {
                        cmdEnderecoTa.Parameters.AddWithValue("@estado_ta", estado);
                        cmdEnderecoTa.Parameters.AddWithValue("@cidade_ta", cidade);
                        cmdEnderecoTa.Parameters.AddWithValue("@rua_ta", rua);
                        cmdEnderecoTa.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    return false;
                }
            }
        }


        public bool logTatico(string email, string senha)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "select * from taticos where email_ta = @email_ta and senha_ta = @senha_ta";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_ta", email);
                        cmd.Parameters.AddWithValue("@senha_ta", senha);

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

        //OPERACIONAL

        public void bancoOrdem(string ordem)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_op (ordem_op) values (@ordem_op)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ordem_op", ordem);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoProgresso(string progresso)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_op (progresso_op) values (@progresso_op)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@progresso_op", progresso);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoMaoDeObra(string alocacao)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_op (mao_obra_op) values (@mao_obra_op)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@mao_obra_op", alocacao);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void bancoAjustes(string ajustes)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "insert into funcao_op (ajustes_op) values (@ajustes_op)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ajustes_op", ajustes);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public bool cadOperacional(string email, string senha, string cpf, int experiencia, decimal salario, string estado, string cidade, string rua, DateTime nascimento, DateTime contratacao)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "select count(*) from operacionais where email_op = @email_op";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@email_op", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("Email já cadastrado.");
                            return false;
                        }
                    }

                    string insertQuery = "insert into operacionais (email_op, senha_op, cpf_op, experiencia_op, salario_op, nascimento_op, contratacao_op) values (@email_op, @senha_op, @cpf_op, @experiencia_op, @salario_op, @nascimento_op, @contratacao_op)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_op", email);
                        cmd.Parameters.AddWithValue("@senha_op", senha);
                        cmd.Parameters.AddWithValue("@cpf_op", cpf);
                        cmd.Parameters.AddWithValue("@experiencia_op", experiencia);
                        cmd.Parameters.AddWithValue("@salario_op", salario);
                        cmd.Parameters.AddWithValue("@nascimento_op", nascimento);
                        cmd.Parameters.AddWithValue("@contratacao_op", contratacao);
                        cmd.ExecuteNonQuery();
                    }
                    string insertOperacionalQuery = "insert into endereço_operacionais (estado_op, cidade_op, rua_op) values (@estado_op, @cidade_op, @rua_op)";
                    using (MySqlCommand cmdEnderecoTa = new MySqlCommand(insertOperacionalQuery, conn))
                    {
                        cmdEnderecoTa.Parameters.AddWithValue("@estado_op", estado);
                        cmdEnderecoTa.Parameters.AddWithValue("@cidade_op", cidade);
                        cmdEnderecoTa.Parameters.AddWithValue("@rua_op", rua);
                        cmdEnderecoTa.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    return false;
                }
            }
        }

        public bool logOperacional(string email, string senha)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "select * from operacionais where email_op = @email_op and senha_op = @senha_op";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_op", email);
                        cmd.Parameters.AddWithValue("@senha_op", senha);

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
        public void mostrarOrdensProducao()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ordem_op, progresso_op, mao_obra_op, ajustes_op FROM operacionais ORDER BY id DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\n=== ORDENS DE PRODUÇÃO ===");
                            while (reader.Read())
                            {
                                Console.WriteLine($"\nOrdem: {reader["ordem_op"]}");
                                Console.WriteLine($"Progresso: {reader["progresso_op"]}");
                                Console.WriteLine($"Mão de obra: {reader["mao_obra_op"]}");
                                Console.WriteLine($"Ajustes: {reader["ajustes_op"]}");
                                Console.WriteLine("----------------------");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void mostrarInfoEstrategica()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT objetivo_es, estrategia_es, equipamentos_es, trabalhadores_es, portifolio_es, local_es FROM estrategicos ORDER BY id DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("\n=== INFORMAÇÕES ESTRATÉGICAS ===");
                                Console.WriteLine($"Objetivo: {reader["objetivo_es"]}");
                                Console.WriteLine($"Estratégia: {reader["estrategia_es"]}");
                                Console.WriteLine($"Equipamentos: {reader["equipamentos_es"]}");
                                Console.WriteLine($"Trabalhadores: {reader["trabalhadores_es"]}");
                                Console.WriteLine($"Portfólio: {reader["portifolio_es"]}");
                                Console.WriteLine($"Local: {reader["local_es"]}");
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma informação estratégica disponível.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void mostrarInfoTatica()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT plano_ta, lotes_ta, cronograma_ta, ajuste_ta, desvios_ta FROM taticos ORDER BY id DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("\n=== INFORMAÇÕES TÁTICAS ===");
                                Console.WriteLine($"Plano: {reader["plano_ta"]}");
                                Console.WriteLine($"Lotes: {reader["lotes_ta"]}");
                                Console.WriteLine($"Cronograma: {reader["cronograma_ta"]}");
                                Console.WriteLine($"Ajuste de capacidade: {reader["ajuste_ta"]}");
                                Console.WriteLine($"Desvios: {reader["desvios_ta"]}");
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma informação tática disponível.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }
    }
}
