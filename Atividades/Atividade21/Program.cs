using System;
using BibliotecaMatriz;
class Program
{
    public static void gerarMatriz(int[,] matriz)
        {
            Random random = new Random();
            int linhas = matriz.GetLength(0);
            int cols = matriz.GetLength(1);

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matriz[i, j] = random.Next(0, 2);
                }
            }
        }
    public static double contarArea(int[,] mat)
    {
        int linhas = mat.GetLength(0);
        int cols = mat.GetLength(1);
        double area = 0;

            for (int i = 0; i < linhas; i++)
                for (int j = 0; j < cols; j++)
                    if(mat[i,j] == 1)
                        area++;
        return area;
    }

    static void Main()
    {
        int linhas, cols;

        Console.WriteLine("___MATRIZ DE COBERTURA VEGETAL___");
        Console.WriteLine("Digite o número de linhas da matriz:");
        linhas = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o número de colunas da matriz:");
        cols = int.Parse(Console.ReadLine());

        int[,] areaAnterior = new int[linhas, cols];
        int[,] areaAtual = new int[linhas, cols];

        gerarMatriz(areaAnterior);
        gerarMatriz(areaAtual);

        Console.WriteLine("___Area anterior___");
        Matriz.mostrarMatriz(areaAnterior);
        Console.WriteLine();
        Console.WriteLine("___Area atual___");
        Matriz.mostrarMatriz(areaAtual);

        double areaCobertaAnterior = contarArea(areaAnterior);
        Console.WriteLine($"Area coberta anterior: {areaCobertaAnterior:F2}");
        
        double areaCobertaAtual = contarArea(areaAtual);
        Console.WriteLine($"Area coberta anterior: {areaCobertaAtual:F2}");
        
        double percentualAnterior = (areaCobertaAnterior/(linhas*cols)) * 100;
        double percentualAtual = (areaCobertaAtual/(linhas*cols)) * 100;

        Console.WriteLine($"Percentual anterior: {percentualAnterior:F2}%");
        Console.WriteLine($"Percentual atual: {percentualAtual:F2}%");
        if(percentualAnterior > percentualAtual)
            Console.WriteLine("A aréa coberta diminuiiu");
        else if(areaCobertaAtual > areaCobertaAnterior)
            Console.WriteLine("A aréa coberta aumentou");
        else 
            Console.WriteLine("A aréa coberta se manteve igual");

        Console.ReadKey();



    }
}