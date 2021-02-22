using System;
using DIO.Series.Entidades;
using DIO.Series.Enums;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        static int generoEscolhido, ano, id;
        static string titulo, descricao;
        static bool MenuFilme = false;

        static void Main(string[] args)
        {
            string escolha = MenuSeries();

            while (!escolha.ToUpper().Equals("X"))
            {
                switch (escolha)
                {
                    case "0":
                        break;
                    case "1":
                        if (MenuFilme)
                        {
                            ListarFilmes();
                            break;
                        }
                        ListarSeries();
                        break;
                    case "2":
                        if (MenuFilme)
                        {
                            InserirFilme();
                            break;
                        }
                        InserirSerie();
                        break;
                    case "3":
                        if (MenuFilme)
                        {
                            AtualizarFilme();
                            break;
                        }
                        AtualizarSerie();
                        break;
                    case "4":
                        if (MenuFilme)
                        {
                            ExcluirFilme();
                            break;
                        }
                        ExcluirSerie();
                        break;
                    case "5":
                        if (MenuFilme)
                        {
                            VisualizarDetalhesDoFilme();
                            break;
                        }
                        VisualizarDetalhesDaSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                escolha = MenuFilme ? MenuFilmes() : MenuSeries();
            }
        }

        private static void VisualizarDetalhesDaSerie()
        {
            Console.WriteLine("digite o id da serie que deseja ver os detalhes: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(serieRepositorio.RetornarPorId(id));
        }

        private static void VisualizarDetalhesDoFilme()
        {
            Console.WriteLine("digite o id do filme que deseja ver os detalhes: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(filmeRepositorio.RetornarPorId(id));
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("digite o id da serie que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            serieRepositorio.Excluir(id);
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("digite o id do filme que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            filmeRepositorio.Excluir(id);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("digite o id da serie que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            ObterDadosDaSerie(id);

            Serie serie = new Serie(id: id,
                                        genero: (Genero)generoEscolhido,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);

            serieRepositorio.Atualizar(id, serie);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("digite o id do filme que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            ObterDadosDoFilme(id);

            Filme filme = new Filme(id: id,
                                    genero: (Genero)generoEscolhido,
                                    titulo: titulo,
                                    descricao: descricao,
                                    ano: ano);

            filmeRepositorio.Atualizar(id, filme);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Insira os dados da nova serie:");

            ObterDadosDaSerie(null);

            Serie serie = new Serie(id: id,
                                        genero: (Genero)generoEscolhido,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);

            serieRepositorio.Inserir(serie);
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Insira os dados do novo filme:");

            ObterDadosDoFilme(null);

            Filme filme = new Filme(id: id,
                                    genero: (Genero)generoEscolhido,
                                    titulo: titulo,
                                    descricao: descricao,
                                    ano: ano);

            filmeRepositorio.Inserir(filme);
        }

        private static void ObterDadosDaSerie(int? idSerie)
        {
            id = idSerie == null ? serieRepositorio.ProximoId() : idSerie.Value;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            generoEscolhido = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do lançamento da serie: ");
            ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            descricao = Console.ReadLine();
        }

        private static void ObterDadosDoFilme(int? idFilme)
        {
            id = idFilme == null ? serieRepositorio.ProximoId() : idFilme.Value;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            generoEscolhido = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo do filme: ");
            titulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do lançamento do filme: ");
            ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do filme: ");
            descricao = Console.ReadLine();
        }

        private static void ListarSeries()
        {
            var lstSeries = serieRepositorio.Listar();

            if (lstSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie cadastrada\n");
                return;
            }

            Console.WriteLine("Lista de Series:");

            foreach (var serie in lstSeries)
            {
                if (serie.VerificarStatus())
                {
                    Console.WriteLine($"Id {serie.retonaId()} foi excluido!");
                    continue;
                }
                Console.WriteLine($"Id {serie.retonaId()}: - {serie.retonaTitulo()}");
            }
        }

        private static void ListarFilmes()
        {
            var lstFilmes= filmeRepositorio.Listar();

            if (lstFilmes.Count == 0)
            {
                Console.WriteLine("Nenhum Filme cadastrado\n");
                return;
            }

            Console.WriteLine("Lista de Filmes:");

            foreach (var filme in lstFilmes)
            {
                if (filme.VerificarStatus())
                {
                    Console.WriteLine($"Id {filme.retonaId()} foi excluido!");
                    continue;
                }
                Console.WriteLine($"Id {filme.retonaId()}: - {filme.retonaTitulo()}");
            }
        }

        private static string MenuSeries()
        {
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("*********- Informe a opcao desejada! -************");
            Console.WriteLine("0- Menu de filmes");
            Console.WriteLine("1- Listar todas as series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- limpar tela");
            Console.WriteLine("x- sair");
            Console.WriteLine("");

            string escolha = Console.ReadLine().ToUpper();
            MenuFilme = escolha.Equals("0") ? true : false;
            Console.WriteLine("");
            return escolha;
        }
        private static string MenuFilmes()
        {
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("*********- Informe a opcao desejada! -************");
            Console.WriteLine("0- Menu de series"); 
            Console.WriteLine("1- Listar todos os Filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- limpar tela");
            Console.WriteLine("x- sair");
            Console.WriteLine("");

            string escolha = Console.ReadLine().ToUpper();
            MenuFilme = escolha.Equals("0") ? false : true;
            Console.WriteLine("");
            return escolha;
        }
    }
}
