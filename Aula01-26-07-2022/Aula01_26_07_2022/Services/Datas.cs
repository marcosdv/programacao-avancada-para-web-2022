namespace Aula01_26_07_2022.Services;

internal class Datas : IDatas
{
    public int ValorSomar { get; private set; }

    private void LerDados()
    {
        Console.Clear();
        Console.WriteLine("Digite a quantidade que deseja somar: ");
        ValorSomar = int.Parse(Console.ReadLine() ?? "0");
    }

    public void SomarHoras()
    {
        LerDados();
        DateTime dataAtual = DateTime.Now.AddHours(ValorSomar);

        Console.WriteLine(dataAtual);
        Console.ReadKey();
    }

    public void SomarMinutos()
    {
        LerDados();
        Console.WriteLine(DateTime.Now.AddMinutes(ValorSomar));
        Console.ReadKey();
    }
    
    public void SomarDias()
    {
        LerDados();
        Console.WriteLine(DateTime.Now.AddDays(ValorSomar));
        Console.ReadKey();
    }
        
    public void SomarMeses()
    {
        LerDados();
        Console.WriteLine(DateTime.Now.AddMonths(ValorSomar));
        Console.ReadKey();
    }

    public void SomarAnos()
    {
        LerDados();
        Console.WriteLine(DateTime.Now.AddYears(ValorSomar));
        Console.ReadKey();
    }
}