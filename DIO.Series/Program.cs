using System;
using DIO.Series.Entidades;
using DIO.Series.Enums;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
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
                        ListarSeries();
                        break;
                    case "4":
                        ListarSeries();
                        break;
                    case "5":
                        ListarSeries();
                        break;
                    case "6":
                        ListarSeries();
                        break;
                    case "7":
                        ListarSeries();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção nao encontrada!");
                }
                escolha = Opcoes();
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Insira os dados da nova serie:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int generoEscolhido = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string tituloDaSerie = Console.ReadLine();

            Console.WriteLine("Digite o ano do lançamento da serie: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string descricao = Console.ReadLine();

            Serie serie = new Serie(id: serieRepositorio.ProximoId(),
                                    genero: (Genero)generoEscolhido,
                                    titulo: tituloDaSerie,
                                    descricao: descricao,
                                    ano: ano );
            serieRepositorio.Inserir(serie);
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
                Console.WriteLine($"Id {serie.retonaId()}: - {serie.retonaTitulo()}");
            }
        }

        private static string Opcoes()
        {
            Console.WriteLine("**************************************************");
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
