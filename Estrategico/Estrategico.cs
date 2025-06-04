using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estrategico
{
    public class Estrategico
    {
        public string nome;
        private decimal salario;
        public string experiencia;
        public string formação;
        public bool status;
        public DateTime contratacao;
        public string cargo;
        public DateTime nascimento;
        public string email;
        private string senha;

        public void objetivoEmpresa(string objetivo)
        {
            Console.WriteLine("Qual será os objetivos da empresa?");
            objetivo = Console.ReadLine();
            bancoObjetivo(objetivo);
            Console.WriteLine("O objetivo foi registrado e sera mandado para os outros funcionarios");
        }

        public void estrategiaEmpresa(string estrategia)
        {
            Console.WriteLine("Qual sera a estrategia que a empresa adotara?");
            estrategia = Console.ReadLine();
            bancoEstrategia(estrategia);
            Console.WriteLine("A estrategia foi registrada e sera mandado para os outros funcionarios");
        }

        public void recursosEmpresa(string equipamentos, int trabalhadores, string materiais)
        {
            Console.WriteLine("Quais equipamentos serão necessarios? E qual a quantidade?");
            equipamentos = Console.ReadLine();
            Console.WriteLine("Quantos trabalhadores serão atribuidos ao projeto?");
            trabalhadores = int.Parse(Console.ReadLine());
            Console.WriteLine("Quais materiais serão utilizados? E qual a quantidade?");
            materiais = Console.ReadLine();
            bancoRecursos(equipamentos, trabalhadores, materiais);
            Console.WriteLine("Recursos necessarios gravados com sucesso!")
        }

        public void portifolioProdutos(string portifolio)
        {
            Console.WriteLine("Quais produtos devem ser priorizadas e quais devem ser descontinuados?");
            portifolio = Console.ReadLine();
            bancoPortifolio(portifolio);
            Console.WriteLine("Portfólio registrado com sucesso!");
        }

        public void localProducao(string local)
        {
            Console.WriteLine("Onde será o novo local de produção?");
            local = Console.ReadLine();
            bancoLocal(local);
            Console.WriteLine("Local registrado com sucesso!");
        }

        public void relacoesExternas(string relacoes)
        {
            Console.WriteLine("Descreva as principais relações com stakeholders (investidores, fornecedores, clientes):");
            relacoes = Console.ReadLine();
            bancoRelacoes(relacoes);
            Console.WriteLine("Relações registradas com sucesso!");
        }
    }
}