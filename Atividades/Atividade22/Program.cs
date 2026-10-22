using System;
using Atividade22;

class Program
{
    static int menu()
    {
        Console.WriteLine("\n=== SISTEMA DE CADASTRO DE BANDAS ===");
        Console.WriteLine("1 - Adicionar Banda");
        Console.WriteLine("2 - Mostrar Bandas");
        Console.WriteLine("3 - Buscar Banda");
        Console.WriteLine("0 - Sair\n");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void mostrarBandas(List<Banda> listaBandas)
    {
        Console.WriteLine("\n___BANDAS CADASTRADAS___");
        for (int i = 0; i < listaBandas.Count; i++) 
        {
            Console.WriteLine($"\nDados da banda {i+1}");
            Console.WriteLine($"Nome: {listaBandas[i].nome}");
            Console.WriteLine($"Gênero: {listaBandas[i].genero}");
            Console.WriteLine($"Quantidade de integrantes: {listaBandas[i].integrantes}");
            Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
        }
    }

    static Banda addBanda(List<Banda> listaBandas) {

        Banda novaBanda = new Banda();

        Console.WriteLine("\nDigite os dados da nova banda: ");
        Console.Write("Nome: ");
        novaBanda.nome = Console.ReadLine();
        Console.Write("Gênero: ");
        novaBanda.genero = Console.ReadLine();
        Console.Write("Número de integrantes: ");
        novaBanda.integrantes = int.Parse(Console.ReadLine());
        Console.Write("Ranking: ");
        novaBanda.ranking = int.Parse(Console.ReadLine());
        listaBandas.Add(novaBanda);

        return novaBanda;
    }
    static void Main()
    {
        List<Banda> listaBandas = new List<Banda>(); //vetor de bandas

        int opcao;
        do
        {
            opcao = menu();
            switch (opcao)
            {
                case 1: addBanda(listaBandas);
                    break;
                case 2: mostrarBandas(listaBandas);
                    break;
                case 0: Console.WriteLine("Saindo...");
                    break;
            }

        } while (opcao != 0);


 
        Console.ReadKey();
    }
}