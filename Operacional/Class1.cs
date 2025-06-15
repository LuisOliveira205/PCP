using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Operacional
{
    public class Operacional
    {
        public string nome;
        public string email;
        private string senha;
        public string cpf;
        private decimal salario;
        public int experiencia;
        public bool login = false;
        public int cod_op = 0;
        public string ordem;
        public string progresso;
        public string alocacao;
        public string ajustes;
        public DateTime nascimento;
        public DateTime contratacao;

        string urlbanco = "server = localhost; database = pcp; uid=root; password = ;";

        public void cadastrarOperacional()
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
                    string queryC = "insert into operacionais (nome_op, email_op, senha_op, cpf_op, salario_op, experiencia_op, nascimento_op, contratacao_op) VALUES (@nome, @email, @senha, @cpf, @salario, @experiencia, @nascimento, @contratacao)";

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

        public void loginOperacional()
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
                    string queryL = "select cod_op from operacionais where email_op = @email and senha_op = @senha";

                    using (MySqlCommand comando = new MySqlCommand(queryL, conexao))
                    {
                        comando.Parameters.AddWithValue("@email", email);
                        comando.Parameters.AddWithValue("@senha", senha);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            cod_op = Convert.ToInt32(resultado);
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

        public void executarOrdem()
        {
            if (login == true)
            {
                Console.WriteLine("Descreva a ordem de produção a ser executada:");
                ordem = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_op where cod_op = @cod_op";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_op", cod_op);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_op set ordem_op = @ordem where cod_op = @cod_op";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdUpdate.Parameters.AddWithValue("@ordem", ordem);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("A ordem de produção foi atualizada com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_op (cod_op, ordem_op) values (@cod_op, @ordem)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdInsert.Parameters.AddWithValue("@ordem", ordem);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("A ordem de produção foi registrada com sucesso.");
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

        public void reportarProgresso()
        {
            if (login == true)
            {
                Console.WriteLine("Descreva o progresso do projeto:");
                progresso = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_op where cod_op = @cod_op";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_op", cod_op);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_op set progresso_op = @progresso where cod_op = @cod_op";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdUpdate.Parameters.AddWithValue("@progresso", progresso);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("O progresso foi atualizado com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_op (cod_op, progresso_op) values (@cod_op, @progresso)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdInsert.Parameters.AddWithValue("@progresso", progresso);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("O progresso foi registrado com sucesso.");
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

        public void gerirMaoDeObra()
        {
            if (login == true)
            {
                Console.WriteLine("Descreva como será feita a alocação da mão de obra:");
                alocacao = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_op where cod_op = @cod_op";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_op", cod_op);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_op set mao_obra_op = @alocacao where cod_op = @cod_op";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdUpdate.Parameters.AddWithValue("@alocacao", alocacao);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("A gestão de mão de obra foi atualizada com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_op (cod_op, mao_obra_op) values (@cod_op, @alocacao)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdInsert.Parameters.AddWithValue("@alocacao", alocacao);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("A gestão de mão de obra foi registrada com sucesso.");
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

        public void ajustesCorrecao()
        {
            if (login == true)
            {
                Console.WriteLine("Descreva os ajustes ou correções feitos:");
                ajustes = Console.ReadLine();

                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();

                        string verifica = "select count(*) from funcao_op where cod_op = @cod_op";
                        using (MySqlCommand cmdVerifica = new MySqlCommand(verifica, conexao))
                        {
                            cmdVerifica.Parameters.AddWithValue("@cod_op", cod_op);
                            long existe = (long)cmdVerifica.ExecuteScalar();

                            if (existe > 0)
                            {
                                string update = "update funcao_op set ajustes_op = @ajustes where cod_op = @cod_op";
                                using (MySqlCommand cmdUpdate = new MySqlCommand(update, conexao))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdUpdate.Parameters.AddWithValue("@ajustes", ajustes);
                                    cmdUpdate.ExecuteNonQuery();
                                    Console.WriteLine("Os ajustes foram atualizados com sucesso.");
                                }
                            }
                            else
                            {
                                string insert = "insert into funcao_op (cod_op, ajustes_op) values (@cod_op, @ajustes)";
                                using (MySqlCommand cmdInsert = new MySqlCommand(insert, conexao))
                                {
                                    cmdInsert.Parameters.AddWithValue("@cod_op", cod_op);
                                    cmdInsert.Parameters.AddWithValue("@ajustes", ajustes);
                                    cmdInsert.ExecuteNonQuery();
                                    Console.WriteLine("Os ajustes foram registrados com sucesso.");
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

        public void visualizarInfoEstrategica()
        {
            if (login == true)
            {
                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();
                        string query = "select * from funcao_es";

                        using (MySqlCommand comando = new MySqlCommand(query, conexao))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("Objetivo: " + reader["objetivo_es"]);
                                    Console.WriteLine("Estratégia: " + reader["estrategia_es"]);
                                    Console.WriteLine("Equipamentos: " + reader["equipamentos_es"]);
                                    Console.WriteLine("Trabalhadores: " + reader["trabalhadores_es"]);
                                    Console.WriteLine("Portfólio: " + reader["portifolio_es"]);
                                    Console.WriteLine("Local: " + reader["local_es"]);
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

        public void visualizarInfoTatica()
        {
            if (login == true)
            {
                try
                {
                    using (MySqlConnection conexao = new MySqlConnection(urlbanco))
                    {
                        conexao.Open();
                        string query = "select * from funcao_ta";

                        using (MySqlCommand comando = new MySqlCommand(query, conexao))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("Plano: " + reader["plano_ta"]);
                                    Console.WriteLine("Lotes: " + reader["lotes_ta"]);
                                    Console.WriteLine("Cronograma: " + reader["cronograma_ta"]);
                                    Console.WriteLine("Ajuste: " + reader["ajuste_ta"]);
                                    Console.WriteLine("Desvios: " + reader["desvios_ta"]);
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
