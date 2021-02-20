using System;
using DIO.Series.Entidades;
using DIO.Series.Enums;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static int generoEscolhido, ano, idSerie;
        static string tituloDaSerie, descricao;

        static void Main(string[] args)
        {
            string escolha = Opcoes();

            while (!escolha.ToUpper().Equals("X"))
            {
                switch (escolha)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarDetalhesDaSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                escolha = Opcoes();
            }
        }

        private static void VisualizarDetalhesDaSerie()
        {
            Console.WriteLine("digite o id da serie que deseja ver os detalhes: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine(serieRepositorio.RetornarPorId(id));
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("digite o id da serie que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            serieRepositorio.Excluir(id);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("digite o id da serie que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine());

            ObterDadosDaSerie(id);

            Serie serie = new Serie(id: idSerie,
                                        genero: (Genero)generoEscolhido,
                                        titulo: tituloDaSerie,
                                        descricao: descricao,
                                        ano: ano);

            serieRepositorio.Atualizar(idSerie, serie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Insira os dados da nova serie:");

            ObterDadosDaSerie(null);

            Serie serie = new Serie(id: idSerie,
                                        genero: (Genero)generoEscolhido,
                                        titulo: tituloDaSerie,
                                        descricao: descricao,
                                        ano: ano);

            serieRepositorio.Inserir(serie);
        }

        private static void ObterDadosDaSerie(int? id)
        {
            idSerie = id == null ? serieRepositorio.ProximoId() : id.Value;

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            generoEscolhido = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            tituloDaSerie = Console.ReadLine();

            Console.WriteLine("Digite o ano do lançamento da serie: ");
            ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
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

        private static string Opcoes()
        {
            Console.WriteLine("\n**************************************************");
            Console.WriteLine("*********- Informe a opcao desejada! -************");
            Console.WriteLine("1- Listar todas as series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- limpar tela");
            Console.WriteLine("x- sair");
            Console.WriteLine("");

            string escolha = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return escolha;
        }
    }
}
