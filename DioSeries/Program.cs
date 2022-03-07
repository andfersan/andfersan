using DioSeries.EnumTitulo;
using DioSeries.Model;
using DioSeries.Repositorio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DioSeries
{
    public class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        private static string opacaoUsuario;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });

            string opacaoUsuario = ObterOpcaoUsuario();

            while (opacaoUsuario.ToUpper() != "X")
            {
                switch (opacaoUsuario)
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
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opacaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nosso servi�os.");
            Console.WriteLine();


        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar s�ries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma s�rie cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Exclu�do" : ""));
            }
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da s�rie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da s�rie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id nova s�rie");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o g�nero entre as op��es acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o T�tulo da s�rie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de incio da s�rie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descri��o da s�rie");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova s�rie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o g�nero entre as op��es acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o T�tulo da s�rie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de incio da s�rie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descri��o da s�rie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!");
            Console.WriteLine("Informe a op��o desejada:");

            Console.WriteLine("1 - Listar s�ries");
            Console.WriteLine("2 - Inserir nova  s�rie");
            Console.WriteLine("3 - Atualizar s�rie");
            Console.WriteLine("4 - Exluir s�rie");
            Console.WriteLine("5 - Visualizar s�rie");
            Console.WriteLine("6 - Limpar s�rie");
            Console.WriteLine("7 - Sair s�rie");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opacaoUsuario;


        }

       
       
            
    }

}
