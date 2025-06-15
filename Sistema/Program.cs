using System;
using Estrategico;
using Tatico;
using Operacional;

namespace Sistema
{
    class Sistema
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema PCP");

            while (true)
            {
                Console.WriteLine("\nSelecione o tipo de usuário:");
                Console.WriteLine("1 - Estratégico");
                Console.WriteLine("2 - Tático");
                Console.WriteLine("3 - Operacional");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
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
                        Console.WriteLine("Saindo do sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void MenuEstrategico()
        {
            Estrategico.Estrategico estrategico = new Estrategico.Estrategico();

            while (true)
            {
                Console.WriteLine("\nMENU ESTRATÉGICO");
                if (!estrategico.login)
                {
                    Console.WriteLine("1 - Cadastrar");
                    Console.WriteLine("2 - Login");
                    Console.WriteLine("0 - Voltar");
                }
                else
                {
                    Console.WriteLine("3 - Definir Objetivos da Empresa");
                    Console.WriteLine("4 - Definir Estratégia da Empresa");
                    Console.WriteLine("5 - Definir Recursos da Empresa");
                    Console.WriteLine("6 - Definir Portfólio de Produtos");
                    Console.WriteLine("7 - Definir Local de Produção");
                    Console.WriteLine("8 - Visualizar Informações Operacionais");
                    Console.WriteLine("9 - Logout");
                }
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1" when !estrategico.login:
                        estrategico.cadastrarEstrategico();
                        break;
                    case "2" when !estrategico.login:
                        estrategico.loginEstrategia();
                        break;
                    case "3" when estrategico.login:
                        estrategico.objetivoempresa();
                        break;
                    case "4" when estrategico.login:
                        estrategico.estrategiaempresa();
                        break;
                    case "5" when estrategico.login:
                        estrategico.recursosempresa();
                        break;
                    case "6" when estrategico.login:
                        estrategico.portifolioprodutos();
                        break;
                    case "7" when estrategico.login:
                        estrategico.localproducao();
                        break;
                    case "8" when estrategico.login:
                        estrategico.visualizarinfooperacional();
                        break;
                    case "9" when estrategico.login:
                        estrategico.login = false;
                        Console.WriteLine("Logout realizado com sucesso!");
                        return;
                    case "0" when !estrategico.login:
                        return;
                    default:
                        Console.WriteLine("Opção inválida ou não permitida no estado atual!");
                        break;
                }
            }
        }

        static void MenuTatico()
        {
            Tatico.Tatico tatico = new Tatico.Tatico();

            while (true)
            {
                Console.WriteLine("\nMENU TÁTICO");
                if (!tatico.login)
                {
                    Console.WriteLine("1 - Cadastrar");
                    Console.WriteLine("2 - Login");
                    Console.WriteLine("0 - Voltar");
                }
                else
                {
                    Console.WriteLine("3 - Definir Plano de Produção");
                    Console.WriteLine("4 - Definir Lotes e Cronograma");
                    Console.WriteLine("5 - Definir Ajustes de Capacidade");
                    Console.WriteLine("6 - Registrar Desvios");
                    Console.WriteLine("7 - Visualizar Informações Operacionais");
                    Console.WriteLine("8 - Logout");
                }
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1" when !tatico.login:
                        tatico.cadastrarTatico();
                        break;
                    case "2" when !tatico.login:
                        tatico.loginTatico();
                        break;
                    case "3" when tatico.login:
                        tatico.planoEmpresa();
                        break;
                    case "4" when tatico.login:
                        tatico.loteCronogramaEmpresa();
                        break;
                    case "5" when tatico.login:
                        tatico.capacidadeEmpresa();
                        break;
                    case "6" when tatico.login:
                        tatico.desviosEmpresa();
                        break;
                    case "7" when tatico.login:
                        tatico.visualizarInfoOperacional();
                        break;
                    case "8" when tatico.login:
                        tatico.login = false;
                        Console.WriteLine("Logout realizado com sucesso!");
                        return;
                    case "0" when !tatico.login:
                        return;
                    default:
                        Console.WriteLine("Opção inválida ou não permitida no estado atual!");
                        break;
                }
            }
        }

        static void MenuOperacional()
        {
            Operacional.Operacional operacional = new Operacional.Operacional();

            while (true)
            {
                Console.WriteLine("\nMENU OPERACIONAL");
                if (!operacional.login)
                {
                    Console.WriteLine("1 - Cadastrar");
                    Console.WriteLine("2 - Login");
                    Console.WriteLine("0 - Voltar");
                }
                else
                {
                    Console.WriteLine("3 - Executar Ordem de Produção");
                    Console.WriteLine("4 - Reportar Progresso");
                    Console.WriteLine("5 - Gerenciar Mão de Obra");
                    Console.WriteLine("6 - Registrar Ajustes e Correções");
                    Console.WriteLine("7 - Visualizar Informações Estratégicas");
                    Console.WriteLine("8 - Visualizar Informações Táticas");
                    Console.WriteLine("9 - Logout");
                }
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1" when !operacional.login:
                        operacional.cadastrarOperacional();
                        break;
                    case "2" when !operacional.login:
                        operacional.loginOperacional();
                        break;
                    case "3" when operacional.login:
                        operacional.executarOrdem();
                        break;
                    case "4" when operacional.login:
                        operacional.reportarProgresso();
                        break;
                    case "5" when operacional.login:
                        operacional.gerirMaoDeObra();
                        break;
                    case "6" when operacional.login:
                        operacional.ajustesCorrecao();
                        break;
                    case "7" when operacional.login:
                        operacional.visualizarInfoEstrategica();
                        break;
                    case "8" when operacional.login:
                        operacional.visualizarInfoTatica();
                        break;
                    case "9" when operacional.login:
                        operacional.login = false;
                        Console.WriteLine("Logout realizado com sucesso!");
                        return;
                    case "0" when !operacional.login:
                        return;
                    default:
                        Console.WriteLine("Opção inválida ou não permitida no estado atual!");
                        break;
                }
            }
        }
    }
}
