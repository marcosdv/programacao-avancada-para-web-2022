namespace Aula02_02_08_2022.Models;

public class Resultado
{
    public Resultado(float resultado, Valores valores, string operacao)
    {
        ResultadoCalculo = resultado;
        Formula = $"{valores.Valor1} {operacao} {valores.Valor2} = {resultado}";
    }

    public float ResultadoCalculo { get; set; }
    public string Formula { get; set; }
}
