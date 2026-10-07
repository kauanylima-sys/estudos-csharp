using System;
using BibliotecaVetor;

class ATividadeVetor 
{
    static double calcularMedia(int[] Roubos)
    {
        int TotalDeRoubos = 0;
        double Media = 0.0;
        for (int i = 0; i < Roubos.Length; i++)
        {
            TotalDeRoubos = TotalDeRoubos + Roubos[i];
        }
        Media = (double)TotalDeRoubos/Roubos.Length;
        return Media;
    }
    static void exibirTop3BairrosViolentos(String[] Bairros, int[] Roubos){
        int Primeiro = 0; int Segundo = 0;
        int Terceiro = 0; int indice1 = 0;
        int indice2 = 0; int indice3 = 0;
        
        for(int i = 0; i < Roubos.Length; i++)
        {
            if(Roubos[i] > Primeiro)
            {
                Terceiro = Segundo;  indice3 = indice2;
                Segundo = Primeiro; indice2 = indice1;
                Primeiro = Roubos[i]; indice1 = i;
            }
            else if(Roubos[i] > Segundo)
            {
                Terceiro = Segundo;  indice3 = indice2;
                Segundo = Roubos[i]; indice2 = i;
            }
            else if(Roubos[i] > Terceiro)
            {
                Terceiro = Roubos[i];  indice3 = i;
            }

        }
        Console.WriteLine($"___BAIRROS MAIS PERIGOSOS___");
        Console.WriteLine($"TOP 1: {Bairros[indice1]} Número de roubos = {Primeiro} ");
        Console.WriteLine($"TOP 2: {Bairros[indice2]} Número de roubos = {Segundo} ");
        Console.WriteLine($"TOP 3: {Bairros[indice3]} Número de roubos = {Terceiro} ");

    }


    static void Main()
    {
        int[] Roubos = new int[10];
        String[] Bairros = {"Centro", "Moema", "Pinheiros", "Itaquera", "Tatuapé","Santo Amaro", "Vila Mariana", "Lapa", "Capão Redondo", "Santana"};
        
        Console.WriteLine("___Quantidades de roubo de cada região____");
        Vetor.lerVetor(Roubos);

        exibirTop3BairrosViolentos(Bairros, Roubos);

    }
}