using System;

namespace CRUD.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while(opcaoUsuario.ToUpper() != "X")
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
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                    
               }

               opcaoUsuario = ObterOpcaoUsuario();
           }

           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.ReadLine();
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indeceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da série: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indeceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da série: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Generos)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Generos),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGeneros = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indeceSerie,
                                            genero: (Generos)entradaGeneros,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indeceSerie,atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Generos)))
            {
                Console.WriteLine("{0}-{1}", i,Enum.GetName(typeof(Generos),i));
            }
            Console.WriteLine("Digite o genero entre as opções a cima: ");
            int entradaGeneros = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série :");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                        genero: (Generos)entradaGeneros,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            
            Console.WriteLine();

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
