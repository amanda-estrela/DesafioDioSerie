using System;
using static System.Console;


namespace DioSeries
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();

          while(opcaoUsuario.ToUpper() != "X")
          {
              switch(opcaoUsuario)
              {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                   // AtualizarSerie();
                    break;
                case "4":
                   // ExcluirSerie();
                    break;
                case "5":
                   // VisualizarSerie();
                    break;
                case "C":
                    Clear();
                    break;

                default:
                throw new ArgumentOutOfRangeException();
              }

            WriteLine("Obrigada por utilizar nossos serviços.");
            ReadLine();
          }
        }

        private static void ListarSeries()
        {
            WriteLine("Listar séries");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                WriteLine("#ID {0}: - {1} ", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(ReadLine());

            Write("Digite o título da série: ");
            string entradaTitulo = ReadLine();

            Write("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(ReadLine());

            Write("Digite a descrição da série: ");
            string entradaDescricao = ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            WriteLine();
            WriteLine("Dio Séries a seu dispor!!!");
            WriteLine("Informe a opção desejada: ");

            WriteLine("1 - Listar séries");
            WriteLine("2 - Inserir nova série");
            WriteLine("3 - Atualizar série");
            WriteLine("4 - Excluir série");
            WriteLine("5 - Visualizar série");
            WriteLine("C - Limpar tela");
            WriteLine("X - Sair");
            WriteLine();

            string opcaoUsuario = ReadLine().ToUpper();
            WriteLine();
            return opcaoUsuario;

        }
    }
}