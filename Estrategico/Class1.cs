using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Estrategico
{
    public class Estrategico
    {
        public string nome;
        public string email;
        private string senha;
        public string cpf;
        private decimal salario;
        public int experiencia;
        public bool login = false;
        public int cod_es = 0;
        public string objetivo;
        public string estrategia;
        public string equipamentos;
        public int trabalhadores;
        public string portifolio;
        public string local;
        public DateTime nascimento;
        public DateTime contratacao;

        string urlbanco = "server = localhost; database = pcp; uid=root; password = ;";

        public void cadastrarEstrategico()
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
                    string queryC = "insert into estrategicos (nome_es, email_es, senha_es, cpf_es, salario_es, experiencia_es, nascimento_es, contratacao_es) VALUES (@nome, @email, @senha, @cpf, @salario, @experiencia, @nascimento, @contratacao)";

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
        public void loginEstrategia()
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
                    string queryL = "select cod_es from estrategicos where email_es = @email and senha_es = @senha";

                    using (MySqlCommand comando = new MySqlCommand(queryL, conexao))
                    {
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@senha", senha);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            cod_es = Convert.ToInt32(resultado);
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
        public void objetivoempresa()
        {
            if (login == true)
            {
                Console.WriteLine("qual será os objetivos da empresa?");
                objetivo = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_es where cod_es = @cod_es";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_es", cod_es);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_es set objetivo_es = @objetivo where cod_es = @cod_es";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdUpdate.Parameters.AddWithValue("@objetivo", objetivo);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("O objetivo foi atualizado com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_es (cod_es, objetivo_es) values (@cod_es, @objetivo)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdInsert.Parameters.AddWithValue("@objetivo", objetivo);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("O objetivo foi registrado e será enviado para os outros funcionários.");
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
        public void estrategiaempresa()
        {
            if (login == true)
            {
                Console.WriteLine("Qual será a estratégia que a empresa adotará?");
                estrategia = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_es where cod_es = @cod_es";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_es", cod_es);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_es set estrategia_es = @estrategia where cod_es = @cod_es";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdUpdate.Parameters.AddWithValue("@estrategia", estrategia);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("A estratégia foi atualizada com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_es (cod_es, estrategia_es) values (@cod_es, @estrategia)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdInsert.Parameters.AddWithValue("@estrategia", estrategia);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("A estratégia foi registrada e será enviada para os outros funcionários.");
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

        public void recursosempresa()
        {
            if (login == true)
            {
                Console.WriteLine("Quais equipamentos serão necessários?");
                equipamentos = Console.ReadLine();
                Console.WriteLine("Quantos trabalhadores serão atribuídos?");
                trabalhadores = int.Parse(Console.ReadLine());

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_es where cod_es = @cod_es";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_es", cod_es);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_es set equipamentos_es = @equipamentos, trabalhadores_es = @trabalhadores where cod_es = @cod_es";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdUpdate.Parameters.AddWithValue("@equipamentos", equipamentos);
                                    cmdUpdate.Parameters.AddWithValue("@trabalhadores", trabalhadores);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("Os recursos foram atualizados com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_es (cod_es, equipamentos_es, trabalhadores_es) values (@cod_es, @equipamentos, @trabalhadores)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdInsert.Parameters.AddWithValue("@equipamentos", equipamentos);
                                    cmdInsert.Parameters.AddWithValue("@trabalhadores", trabalhadores);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("Os recursos foram registrados com sucesso.");
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

        public void portifolioprodutos()
        {
            if (login == true)
            {
                Console.WriteLine("Quais produtos devem ser priorizados e quais devem ser descontinuados?");
                portifolio = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_es where cod_es = @cod_es";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_es", cod_es);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_es set portifolio_es = @portifolio where cod_es = @cod_es";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdUpdate.Parameters.AddWithValue("@portifolio", portifolio);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("O portfólio foi atualizado com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_es (cod_es, portifolio_es) values (@cod_es, @portifolio)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdInsert.Parameters.AddWithValue("@portifolio", portifolio);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("O portfólio foi registrado com sucesso.");
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

        public void localproducao()
        {
            if (login == true)
            {
                Console.WriteLine("Onde será o novo local de produção?");
                local = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_es where cod_es = @cod_es";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_es", cod_es);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_es set local_es = @local where cod_es = @cod_es";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdUpdate.Parameters.AddWithValue("@local", local);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("O local de produção foi atualizado com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_es (cod_es, local_es) values (@cod_es, @local)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_es", cod_es);
                                    cmdInsert.Parameters.AddWithValue("@local", local);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("O local de produção foi registrado com sucesso.");
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

        public void visualizarinfooperacional()
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
