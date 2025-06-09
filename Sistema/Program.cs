using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BancoPCP;
using Estrategico;
using Tatico;
using Operacional;

namespace Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA PCP ===");
                Console.WriteLine("Escolha o nível de atuação:");
                Console.WriteLine("1 - Estratégico");
                Console.WriteLine("2 - Tático");
                Console.WriteLine("3 - Operacional");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                string opcaoNivel = Console.ReadLine();

                switch (opcaoNivel)
                {
                    case "1":
                        MenuEstrategico();
                        break;
                    case "2":
                        MenuTatico();
                        break;
                    case "3":
                        MenuOperacional();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MenuEstrategico()
        {
            Estrategico.Estrategico est = new Estrategico.Estrategico();
            bool logado = false;

            Console.Clear();
            Console.WriteLine("=== Módulo Estratégico ===");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Login");
            Console.Write("Escolha: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    est.cadastrarEstrategico();
                    break;
                case "2":
                    est.loginEstrategia();
                    logado = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            if (!logado)
            {
                Console.WriteLine("É necessário fazer login para acessar as opções.");
                return;
            }

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Ações Estratégicas ===");
                Console.WriteLine("1 - Definir Objetivos");
                Console.WriteLine("2 - Definir Estratégias");
                Console.WriteLine("3 - Recursos da Empresa");
                Console.WriteLine("4 - Portfólio de Produtos");
                Console.WriteLine("5 - Local de Produção");
                Console.WriteLine("6 - Visualizar Informações Operacionais");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha: ");
                escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        est.objetivoEmpresa("");
                        break;
                    case "2":
                        est.estrategiaEmpresa("");
                        break;
                    case "3":
                        est.recursosEmpresa("", 0);
                        break;
                    case "4":
                        est.portifolioProdutos("");
                        break;
                    case "5":
                        est.localProducao("");
                        break;
                    case "6":
                        est.visualizarInfoOperacional();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (continuar && escolha != "0")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MenuTatico()
        {
            Tatico.Tatico tat = new Tatico.Tatico();
            bool logado = false;

            Console.Clear();
            Console.WriteLine("=== Módulo Tático ===");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Login");
            Console.Write("Escolha: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    tat.cadastrarTatico();
                    break;
                case "2":
                    tat.loginTatico();
                    logado = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            if (!logado)
            {
                Console.WriteLine("É necessário fazer login para acessar as opções.");
                return;
            }

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Ações Táticas ===");
                Console.WriteLine("1 - Plano da Empresa");
                Console.WriteLine("2 - Lotes e Cronograma");
                Console.WriteLine("3 - Ajuste de Capacidade");
                Console.WriteLine("4 - Desvios");
                Console.WriteLine("5 - Visualizar Informações Operacionais");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha: ");
                escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        tat.planoEmpresa("");
                        break;
                    case "2":
                        tat.loteCronogramaEmpresa("", "");
                        break;
                    case "3":
                        tat.capacidadeEmpresa("");
                        break;
                    case "4":
                        tat.desviosEmpresa("");
                        break;
                    case "5":
                        tat.visualizarInfoOperacional();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (continuar && escolha != "0")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MenuOperacional()
        {
            Operacional.Operacional op = new Operacional.Operacional();
            bool logado = false;

            Console.Clear();
            Console.WriteLine("=== Módulo Operacional ===");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Login");
            Console.Write("Escolha: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    op.cadastrarOperacional();
                    break;
                case "2":
                    op.loginOperacional();
                    logado = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }

            if (!logado)
            {
                Console.WriteLine("É necessário fazer login para acessar as opções.");
                return;
            }

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Ações Operacionais ===");
                Console.WriteLine("1 - Executar Ordem");
                Console.WriteLine("2 - Reportar Progresso");
                Console.WriteLine("3 - Gerir Mão de Obra");
                Console.WriteLine("4 - Ajustes/Correções");
                Console.WriteLine("5 - Visualizar Informações Estratégicas");
                Console.WriteLine("6 - Visualizar Informações Táticas");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha: ");
                escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        op.executarOrdem("");
                        break;
                    case "2":
                        op.reportarProgresso("");
                        break;
                    case "3":
                        op.gerirMaoDeObra("");
                        break;
                    case "4":
                        op.ajustesCorrecao("");
                        break;
                    case "5":
                        op.visualizarInfoEstrategica();
                        break;
                    case "6":
                        op.visualizarInfoTatica();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (continuar && escolha != "0")
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
