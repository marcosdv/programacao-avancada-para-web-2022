using Aula01_26_07_2022.Services;

namespace Aula01_26_07_2022;

public class Program
{
    public static void Main(string[] args)
    {
        Menu();
    }

    private static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Selecione a operação matemática: ");
        
        Console.WriteLine("1 - Somar");
        Console.WriteLine("2 - Subtrair");
        Console.WriteLine("3 - Multiplicar");
        Console.WriteLine("4 - Dividir");

        Console.WriteLine("5 - Somar Horas na Data");
        Console.WriteLine("6 - Somar Minutos na Data");
        Console.WriteLine("7 - Somar Dias na Data");
        Console.WriteLine("8 - Somar Meses na Data");
        Console.WriteLine("9 - Somar Anos na Data");

        Console.WriteLine("0 - Sair");

        int opcao = int.Parse(Console.ReadLine() ?? "-1");

        var calcular = new Calcular();
        var datas = new Datas();

        switch (opcao)
        {
            case 1: calcular.Somar(); Menu(); break;
            case 2: calcular.Subtrair(); Menu(); break;
            case 3: calcular.Multiplicar(); Menu(); break;
            case 4: calcular.Dividir(); Menu(); break;
            case 5: datas.SomarHoras(); Menu(); break;
            case 6: datas.SomarMinutos(); Menu(); break;
            case 7: datas.SomarDias(); Menu(); break;
            case 8: datas.SomarMeses(); Menu(); break;
            case 9: datas.SomarAnos(); Menu(); break;
            case 0: Environment.Exit(0); break;
            default: Menu(); break;
        }
    }
}