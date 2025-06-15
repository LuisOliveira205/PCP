using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tatico
{
    public class Tatico
    {
        public string nome;
        public string email;
        private string senha;
        public string cpf;
        private decimal salario;
        public int experiencia;
        public bool login = false;
        public int cod_ta = 0;
        public string plano;
        public string lotes;
        public string cronograma;
        public string ajuste;
        public string desvios;
        public DateTime nascimento;
        public DateTime contratacao;

        string urlbanco = "server = localhost; database = pcp; uid=root; password = ;";

        public void cadastrarTatico()
        {
            Console.WriteLine("Escreva seu nome");
            nome = Console.ReadLine();
            Console.WriteLine("Escreva seu email");
            email = Console.ReadLine();
            Console.WriteLine("Crie uma senha");
            senha = Console.ReadLine();
            Console.WriteLine("Digite seu CPF");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite seus anos de experiência");
            experiencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite sua data de nascimento (aaaa-mm-dd)");
            nascimento = DateTime.Parse(Console.ReadLine());
            contratacao = DateTime.Now;

            if (experiencia >= 1 && experiencia <= 3)
            {
                salario = 3036;
            }
            else if (experiencia >= 4 && experiencia <= 6)
            {
                salario = 4554;
            }
            else if (experiencia >= 7)
            {
                salario = 6072;
            }
            else
            {
                Console.WriteLine("Ano de experiência inválido");
                return;
            }

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                {
                    conexao.Open();
                    string queryC = "insert into taticos (nome_ta, email_ta, senha_ta, cpf_ta, salario_ta, experiencia_ta, nascimento_ta, contratacao_ta) VALUES (@nome, @email, @senha, @cpf, @salario, @experiencia, @nascimento, @contratacao)";

                    using (MySqlCommand comando = new MySqlCommand(queryC, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@senha", senha);
                        comando.Parameters.AddWithValue("@cpf", cpf);
                        comando.Parameters.AddWithValue("@salario", salario);
                        comando.Parameters.AddWithValue("@experiencia", experiencia);
                        comando.Parameters.AddWithValue("@nascimento", nascimento);
                        comando.Parameters.AddWithValue("@contratacao", contratacao);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public void loginTatico()
        {
            Console.WriteLine("Digite seu email");
            email = Console.ReadLine();
            Console.WriteLine("Digite sua senha");
            senha = Console.ReadLine();

            using (MySqlConnection conexao = new MySqlConnection(urlbanco))
            {
                try
                {
                    conexao.Open();
                    string queryL = "select cod_ta from taticos where email_ta = @email and senha_ta = @senha";

                    using (MySqlCommand comando = new MySqlCommand(queryL, conexao))
                    {
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@senha", senha);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            cod_ta = Convert.ToInt32(resultado);
                            login = true;
                        }
                        else
                        {
                            Console.WriteLine("Email ou senha incorretos.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }

        public void planoEmpresa()
        {
            if (login == true)
            {
                Console.WriteLine("Descreva o plano de produção");
                plano = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_ta where cod_ta = @cod_ta";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_ta", cod_ta);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_ta set plano_ta = @plano where cod_ta = @cod_ta";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdUpdate.Parameters.AddWithValue("@plano", plano);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("O plano foi atualizado com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_ta (cod_ta, plano_ta) values (@cod_ta, @plano)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdInsert.Parameters.AddWithValue("@plano", plano);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("O plano foi registrado com sucesso.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Você precisa estar logado!");
            }
        }

        public void loteCronogramaEmpresa()
        {
            if (login == true)
            {
                Console.WriteLine("Defina o tamanho dos lotes de produção");
                lotes = Console.ReadLine();
                Console.WriteLine("Defina o cronograma de produção:");
                cronograma = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_ta where cod_ta = @cod_ta";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_ta", cod_ta);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_ta set lotes_ta = @lotes, cronograma_ta = @cronograma where cod_ta = @cod_ta";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdUpdate.Parameters.AddWithValue("@lotes", lotes);
                                    cmdUpdate.Parameters.AddWithValue("@cronograma", cronograma);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("Lotes e cronograma foram atualizados com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_ta (cod_ta, lotes_ta, cronograma_ta) values (@cod_ta, @lotes, @cronograma)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdInsert.Parameters.AddWithValue("@lotes", lotes);
                                    cmdInsert.Parameters.AddWithValue("@cronograma", cronograma);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("Lotes e cronograma foram registrados com sucesso.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Você precisa estar logado!");
            }
        }

        public void capacidadeEmpresa()
        {
            if (login == true)
            {
                Console.WriteLine("Qual será o ajuste de capacidade? (ex: contratar, terceirizar, novas máquinas)");
                ajuste = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_ta where cod_ta = @cod_ta";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_ta", cod_ta);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_ta set ajuste_ta = @ajuste where cod_ta = @cod_ta";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdUpdate.Parameters.AddWithValue("@ajuste", ajuste);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("O ajuste de capacidade foi atualizado com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_ta (cod_ta, ajuste_ta) values (@cod_ta, @ajuste)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdInsert.Parameters.AddWithValue("@ajuste", ajuste);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("O ajuste de capacidade foi registrado com sucesso.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Você precisa estar logado!");
            }
        }

        public void desviosEmpresa()
        {
            if (login == true)
            {
                Console.WriteLine("Descreva os desvios identificados");
                desvios = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_ta where cod_ta = @cod_ta";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_ta", cod_ta);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_ta set desvios_ta = @desvios where cod_ta = @cod_ta";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdUpdate.Parameters.AddWithValue("@desvios", desvios);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("Os desvios foram atualizados com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_ta (cod_ta, desvios_ta) values (@cod_ta, @desvios)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_ta", cod_ta);
                                    cmdInsert.Parameters.AddWithValue("@desvios", desvios);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("Os desvios foram registrados com sucesso.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Você precisa estar logado!");
            }
        }

        public void visualizarInfoOperacional()
        {
            if (login == true)
            {
                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();
                        string query = "select * from funcao_op";

                        using (MySqlCommand comando = new MySqlCommand(query, conexao))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("Ordem de Produção: " + reader["ordem_op"]);
                                    Console.WriteLine("Progresso: " + reader["progresso_op"]);
                                    Console.WriteLine("Mão de Obra: " + reader["mao_obra_op"]);
                                    Console.WriteLine("Ajustes Necessários: " + reader["ajustes_op"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Você precisa estar logado!");
            }
        }
    }
}
