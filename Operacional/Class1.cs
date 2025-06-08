using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BancoPCP;

namespace Operacional
{
    public class Operacional
    {
        private ConnBD conn = new ConnBD();

        public string nome;
        public string email;
        private string senha;
        public string cpf;
        private decimal salario;
        public string formação;
        public string experiencia;
        public string cargo;
        public bool status;
        public DateTime contratacao;
        public DateTime nascimento;

        public void cadastrarOperacional()
        {
            Console.WriteLine("Escreva seu Email");
            email = Console.ReadLine();
            Console.WriteLine("Crie uma Senha");
            senha = Console.ReadLine();
            Console.WriteLine("Digite seu Cpf");
            cpf = Console.ReadLine();
            conn.cadOperacional(email, senha, cpf);
            Console.WriteLine("Cadastrado com sucesso!");
        }

        public void loginOperacional()
        {
            Console.WriteLine("Digite seu email");
            email = Console.ReadLine();
            Console.WriteLine("Digite sua senha");
            senha = Console.ReadLine();
            conn.logOperacional(email, senha);
        }

        public void executarOrdem(string ordem)
        {
            Console.WriteLine("Descreva a ordem de produção a ser executada:");
            ordem = Console.ReadLine();
            conn.bancoOrdem(ordem);
            Console.WriteLine("Ordem de produção registrada com sucesso!");
        }

        public void reportarProgresso(string progresso)
        {
            Console.WriteLine("Descreva o progresso do projeto:");
            progresso = Console.ReadLine();
            conn.bancoProgresso(progresso);
            Console.WriteLine("Progresso registrado com sucesso!");
        }

        public void gerirMaoDeObra(string alocacao)
        {
            Console.WriteLine("Descreva como será feita a alocação da mão de obra:");
            alocacao = Console.ReadLine();
            conn.bancoMaoDeObra(alocacao);
            Console.WriteLine("Gestão de mão de obra registrada com sucesso!");
        }

        public void ajustesCorrecao(string ajustes)
        {
            Console.WriteLine("Descreva os ajustes ou correções feitos:");
            ajustes = Console.ReadLine();
            conn.bancoAjustes(ajustes);
            Console.WriteLine("Ajustes registrados com sucesso!");
        }

        public void visualizarInfoEstrategica()
        {
            conn.mostrarInfoEstrategica();
        }

        public void visualizarInfoTatica()
        {
            conn.mostrarInfoTatica();
        }
    }
}