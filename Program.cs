using System;

namespace Series
{

    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main (string[] arqs)
        {
           
            string opcaoUsuario = ObterOpcaoUsuario();

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

                 opcaoUsuario = ObterOpcaoUsuario(); 
                 
            }
            System.Console.WriteLine("Obrigado");
            System.Console.ReadLine();
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID (0):*** {1} *** {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "Excluído" : ""));
            }
        }

        private static void InserirSeries()
        {
            System.Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));    
            }
            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero:(Genero)entradaGenero, Titulo: entradaTitulo, Ano: entradaAno, Descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

                         
        }

        private static void AtualizarSeries()
        {
            Console.Write ("Digite o id da Série: " );
            int indiceSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));       
        }
             System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie AtualizarSerie = new Serie(id: repositorio.ProximoId(), genero:(Genero)entradaGenero, Titulo: entradaTitulo, Ano: entradaAno, Descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, AtualizarSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write ("Digite o id da Série: " );
            int indiceSerie = int.Parse(Console.ReadLine());
        
            repositorio.Exclui(indiceSerie);
        
        }

         private static void VisualizarSerie()
        {
            Console.Write ("Digite o id da Série: " );
            int indiceSerie = int.Parse(Console.ReadLine());
        
            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        
        }
        

            private static string ObterOpcaoUsuario()
            {

            System.Console.WriteLine();
            System.Console.WriteLine("Informe a opção desejada: ");
            System.Console.WriteLine("1 - Listar Séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return ObterOpcaoUsuario;

        }

    }

}
