using System;
using series.Models;
using series.Enum;

namespace series{

    class Progam{

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args){

            string opcaoUsuario = ObterOpçaousuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                 switch (opcaoUsuario)
                 {
                     
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSeries();
                        break;

                    case "3":
                        AtualizarSeries();
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
                
                opcaoUsuario = ObterOpçaousuario();

            }

        }

        //LISTAR SÉRIES
        public static void ListarSeries(){

            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {
                
                var excluido = serie.RetornaExcluido();


                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "Excluído" : ""));   
            }

        }

        //INSERIR SÉRIES
        public static void InserirSeries(){

            System.Console.WriteLine("Inserir Série");

            foreach (int i in Genero.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Insere(novaSerie);

        }

        //ATUALIZAR SÉRIES
        private static void AtualizarSeries(){

            ListarSeries();

             System.Console.WriteLine("Digite o ID da série: ");
             int indiceSerie = int.Parse(Console.ReadLine());

            //  foreach (int i in Genero.GetValues(typeof(Genero)))
            // {
            //     System.Console.WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero), i));
            // }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Atualizar(indiceSerie,atualizarSerie);

        }

        //REMOVER SERIES

        private static void ExcluirSerie(){

            ListarSeries();
            

            System.Console.WriteLine("Digite oo ID da série que deseja excluir");
            int indiceSerie = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            repositorio.Excluir(indiceSerie);
        }
        
        //VISUALIZAR SERIE
        public static void VisualizarSerie(){

            System.Console.WriteLine("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            System.Console.WriteLine();

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }

        private static string ObterOpçaousuario(){

            System.Console.WriteLine();
            System.Console.WriteLine("DIO Séries a seu dispor!!!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1 - Listar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualzar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
            
        }
    }
}
