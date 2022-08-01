namespace Aula01_26_07_2022.Services;

internal class Calcular : ICalcular
{
    private float Valor1;
    private float Valor2;

    private void LerDados()
    {
        Console.Clear();

        Console.WriteLine("Digite o 1º valor: ");
        Valor1 = float.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Digite o 2º valor: ");
        Valor2 = float.Parse(Console.ReadLine() ?? "0");
    }

    public void Somar()
    {
        LerDados();

        float resultado = Valor1 + Valor2;

        Console.WriteLine($"{Valor1} + {Valor2} = {resultado}");
        Console.ReadKey();
    }

    public void Subtrair()
    {
        LerDados();

        float resultado = Valor1 - Valor2;

        Console.WriteLine($"{Valor1} - {Valor2} = {resultado}");
        Console.ReadKey();
    }

    public void Multiplicar()
    {
        LerDados();

        float resultado = Valor1 * Valor2;

        Console.WriteLine($"{Valor1} x {Valor2} = {resultado}");
        Console.ReadKey();
    }

    public void Dividir()
    {
        LerDados();

        float resultado = Valor1 / Valor2;

        Console.WriteLine($"{Valor1} / {Valor2} = {resultado}");
        Console.ReadKey();
    }
}