using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BancoPCP;

namespace Tatico
{
    public class Tatico
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

        public void cadastrarEstrategico()
        {
            Console.WriteLine("Escreva seu Email");
            email = Console.ReadLine();
            Console.WriteLine("Crie uma Senha");
            senha = Console.ReadLine();
            Console.WriteLine("Digite seu Cpf");
            cpf = Console.ReadLine();
            conn.cadEstrategico(email, senha, cpf);
            Console.WriteLine("Cadastrado com sucesso!");
        }

        public void loginEstrategia()
        {
            Console.WriteLine("Digite seu email");
            email = Console.ReadLine();
            Console.WriteLine("Digite sua senha");
            senha = Console.ReadLine();
            conn.logEstrategico(email, senha);
        }

        public void planoEmpresa(string plano)
        {
            Console.WriteLine("Descreva o plano de produção (médio prazo)");
            plano = Console.ReadLine();
            conn.bancoPlano(plano);
            Console.WriteLine("Plano de produção registrado com sucesso!");
        }

        public void loteCronogramaEmpresa(string lotes, string cronograma)
        {
            Console.WriteLine("Defina o tamanho dos lotes de produção");
            lotes = Console.ReadLine();
            Console.WriteLine("Defina o cronograma de produção:");
            cronograma = Console.ReadLine();
            conn.bancoLotesCronograma(lotes, cronograma);
            Console.WriteLine("Lotes e cronograma registrados com sucesso!");
        }

        public void capacidadeEmpresa(string ajuste)
        {
            Console.WriteLine("Qual será o ajuste de capacidade? (ex: contratar, terceirizar, novas máquinas)");
            ajuste = Console.ReadLine();
            conn.bancoCapacidade(ajuste);
            Console.WriteLine("Ajuste de capacidade registrado com sucesso!");
        }

        public void desviosEmpresa(string desvios)
        {
            Console.WriteLine("Descreva os desvios identificados");
            desvios = Console.ReadLine();
            conn.bancoDesvios(desvios);
            Console.WriteLine("Desvios registrados com sucesso!");
        }

        public void visualizarInfoOperacional()
        {
            conn.mostrarOrdensProducao();
        }
    }
}
