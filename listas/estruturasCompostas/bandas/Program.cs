using System;
using System.ComponentModel;
using Bandas;

class Program
{
    static int menu()
    {
        Console.WriteLine("\n=== SISTEMA DE CADASTRO DE BANDAS ===");
        Console.WriteLine("1 - Adicionar Banda");
        Console.WriteLine("2 - Mostrar Bandas");
        Console.WriteLine("3 - Buscar Banda");
        Console.WriteLine("4 - Atualizar Banda");
        Console.WriteLine("5 - Remover Banda");
        Console.WriteLine("6 - Pesquisa por Ranking");
        Console.WriteLine("7 - Pesquisa por Genero");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void addBanda(List<Banda> listaBandas)
    {
        Banda newBanda = new Banda();

        Console.Write("Digite o nome da banda: ");
        newBanda.nome = Console.ReadLine();
        Console.Write("Digite o genero da banda: ");
        newBanda.genero = Console.ReadLine();
        Console.Write("Digite a quantidade de integrantes da banda: ");
        newBanda.integrantes = int.Parse(Console.ReadLine());
        Console.Write("Digite o ranking da banda: ");
        newBanda.ranking = int.Parse(Console.ReadLine());

        listaBandas.Add(newBanda);
    }

    static void showBandas(List<Banda> listaBandas)
    {
        Console.WriteLine("______LISTA DE BANDAS______\n");
        for (int i = 0; i < listaBandas.Count; i++)
        {
            Console.WriteLine($"*** Banda {i + 1} ***");
            Console.WriteLine($"Nome: {listaBandas[i].nome}");
            Console.WriteLine($"Gênero: {listaBandas[i].genero}");
            Console.WriteLine($"Quantidade de integrantes: {listaBandas[i].integrantes}");
            Console.WriteLine($"Ranking (Favoritos): {listaBandas[i].ranking}");
        }
    }

    static void salvarDados(List<Banda> listaBandas, string nomeArquiivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquiivo);

        foreach (Banda banda in listaBandas)
        {
            writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
        }

        Console.WriteLine("Dados salvos com suceso");
    }

    static void buscarPorRanking(List<Banda> listaBandas, int Ranking)
    {
        for (int i = 0; i < listaBandas.Count; i++)
        {
            if (listaBandas[i].ranking == Ranking)
            {
                Console.WriteLine($"*** Banda {i + 1} ***");
                Console.WriteLine($"Nome: {listaBandas[i].nome}");
                Console.WriteLine($"Gênero: {listaBandas[i].genero}");
                Console.WriteLine($"Quantidade de integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking (Favoritos): {listaBandas[i].ranking}");
            }
        }
    }

    static void buscarPorGenero(List<Banda> listaBandas, string genero)
    {
        for (int i = 0; i < listaBandas.Count; i++)
        {
            if (listaBandas[i].genero == genero)
            {
                Console.WriteLine($"*** Banda {i + 1} ***");
                Console.WriteLine($"Nome: {listaBandas[i].nome}");
                Console.WriteLine($"Gênero: {listaBandas[i].genero}");
                Console.WriteLine($"Quantidade de integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking (Favoritos): {listaBandas[i].ranking}");
            }
        }
    }

    static void buscarPorNome(List<Banda> listaBandas, string nome)
    {
        for (int i = 0; i < listaBandas.Count; i++)
        {
            if (listaBandas[i].nome.ToLower() == nome.ToLower())
            {
                Console.WriteLine($"*** Banda {i + 1} ***");
                Console.WriteLine($"Nome: {listaBandas[i].nome}");
                Console.WriteLine($"Gênero: {listaBandas[i].genero}");
                Console.WriteLine($"Quantidade de integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking (Favoritos): {listaBandas[i].ranking}");
            }
            else
            {
                Console.WriteLine("Não foi possível encontrar uma banda com esse nome.");
            }
        }
    }

    static int buscarIndice(List<Banda> listaBandas, string nome)
    {
        int indice = -1;

        for (int i = 0; i < listaBandas.Count; i++)
        {
            if (listaBandas[i].nome.ToLower() == nome.ToLower())
            {
                indice = i;
            }
        }

        return indice;
    }

    static void updateBanda(List<Banda> listaBandas, string nome)
    {
        int i = buscarIndice(listaBandas, nome);
        if (i != -1)
        {
            Console.Write("Digite o nome da banda: ");
            listaBandas[i].nome = Console.ReadLine();
            Console.Write("Digite o genero da banda: ");
            listaBandas[i].genero = Console.ReadLine();
            Console.Write("Digite a quantidade de integrantes da banda: ");
            listaBandas[i].integrantes = int.Parse(Console.ReadLine());
            Console.Write("Digite o ranking da banda: \n");
            listaBandas[i].ranking = int.Parse(Console.ReadLine());
        }
    }

    static bool deleteBanda(List<Banda> listaBandas, string nome)
    {
        int i = buscarIndice(listaBandas, nome);
        if (i != -1)
        {
            if (i != -1)
            {
                Console.Write("Confirma a remoção da banda? (1-Sim / 2-Não): ");
                int confirmacao = int.Parse(Console.ReadLine());
                if (confirmacao == 1)
                {
                    listaBandas.RemoveAt(i); // Remova o elemento (RemoveAt) 
                    return true;
                }
            }
            return false;
        }

        static void carregarDados(List<Banda> listadeBandas, string nomeArquivo)
    {

        if (File.Exists(nomeArquivo))
        {
            string[] linhasDoArquivo = File.ReadAllLines(nomeArquivo);

            foreach (string linha in linhasDoArquivo)
            {
                string[] campos = linha.Split(',');
                Banda banda = new Banda();
                banda.nome = campos[0];
                banda.genero = campos[1];
                banda.integrantes = int.Parse(campos[2]);
                banda.ranking = int.Parse(campos[3]);
                listadeBandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static void Main()
    {
        List<Banda> listaBandas = new List<Banda>();
        int opcao;
        carregarDados(listaBandas, "bandas.txt");

        do
        {
            opcao = menu();
            switch (opcao)
            {
                case 1:
                    addBanda(listaBandas);
                    break;

                case 2:
                    showBandas(listaBandas);
                    break;

                case 3:
                    Console.WriteLine("Digite o nome da banda que deseja buscar");
                    string nome = Console.ReadLine();
                    buscarPorNome(listaBandas, nome);
                    break;

                case 4:
                    Console.WriteLine("Digite o nome da banda que deseja atualizar");
                    nome = Console.ReadLine();
                    updateBanda(listaBandas, nome);

                    break;

                case 5:
                    Console.WriteLine("Digite o nome da banda que deseja apagar");
                    nome = Console.ReadLine();
                    deleteBanda(listaBandas, nome);
                    break;

                case 6:
                    Console.WriteLine("Digite o ranking que deseja buscar");
                    int ranking = int.Parse(Console.ReadLine());
                    buscarPorRanking(listaBandas, ranking);

                    break;

                case 7:
                    Console.WriteLine("Digite o genero que deseja buscar");
                    string genero = Console.ReadLine();
                    buscarPorGenero(listaBandas, genero);
                    break;

                case 0:
                    Console.WriteLine("Encerrando...");
                    salvarDados(listaBandas, "bandas.txt");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (opcao != 0);

    }
}