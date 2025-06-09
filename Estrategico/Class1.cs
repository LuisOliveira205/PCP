using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BancoPCP;

namespace Estrategico
{
    public class Estrategico
    {
        private ConnBD conn = new ConnBD();

        public string nome;
        public string email;
        private string senha;
        public string cpf;
        public string estado;
        public string cidade;
        public string rua;
        private decimal salario;
        public int experiencia;
        public DateTime nascimento;
        public DateTime contratacao;

        public void cadastrarEstrategico()
        {
            Console.WriteLine("Escreva seu Email");
            email = Console.ReadLine();
            Console.WriteLine("Crie uma Senha");
            senha = Console.ReadLine();
            Console.WriteLine("Digite seu Cpf");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite sua Data de Nascimento (aaaa-mm-dd)");
            nascimento = DateTime.Parse(Console.ReadLine());
            contratacao = DateTime.Now;
            Console.WriteLine("Digite seus anos de experiência");
            experiencia = int.Parse(Console.ReadLine());

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
                Console.WriteLine("Ano de experiência inválido.");
                return;
            }

            Console.WriteLine("Digite seu Estado:");
            estado = Console.ReadLine();
            Console.WriteLine("Digite sua Cidade:");
            cidade = Console.ReadLine();
            Console.WriteLine("Digite sua Rua:");
            rua = Console.ReadLine();

            conn.cadEstrategico(email, senha, cpf, experiencia, salario, estado, cidade, rua, nascimento, contratacao);
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

        public void objetivoEmpresa(string objetivo)
        {
            Console.WriteLine("Qual será os objetivos da empresa?");
            objetivo = Console.ReadLine();
            conn.bancoObjetivo(objetivo);
            Console.WriteLine("O objetivo foi registrado e sera mandado para os outros funcionarios");
        }

        public void estrategiaEmpresa(string estrategia)
        {
            Console.WriteLine("Qual sera a estrategia que a empresa adotara?");
            estrategia = Console.ReadLine();
            conn.bancoEstrategia(estrategia);
            Console.WriteLine("A estrategia foi registrada e sera mandado para os outros funcionarios");
        }

        public void recursosEmpresa(string equipamentos, int trabalhadores)
        {
            Console.WriteLine("Quais equipamentos serão necessarios? E qual a quantidade?");
            equipamentos = Console.ReadLine();
            Console.WriteLine("Quantos trabalhadores serão atribuidos ao projeto?");
            trabalhadores = int.Parse(Console.ReadLine());
            conn.bancoRecursos(equipamentos, trabalhadores);
            Console.WriteLine("Recursos necessarios gravados com sucesso!");
        }

        public void portifolioProdutos(string portifolio)
        {
            Console.WriteLine("Quais produtos devem ser priorizadas e quais devem ser descontinuados?");
            portifolio = Console.ReadLine();
            conn.bancoPortifolio(portifolio);
            Console.WriteLine("Portfólio registrado com sucesso!");
        }

        public void localProducao(string local)
        {
            Console.WriteLine("Onde será o novo local de produção?");
            local = Console.ReadLine();
            conn.bancoLocal(local);
            Console.WriteLine("Local registrado com sucesso!");
        }

        public void visualizarInfoOperacional()
        {
            conn.mostrarOrdensProducao();
        }
    }
}
