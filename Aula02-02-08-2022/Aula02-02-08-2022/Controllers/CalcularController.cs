using Aula02_02_08_2022.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula02_02_08_2022.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CalcularController : ControllerBase
{
    [HttpGet("Somar/{valor1}/{valor2}")]
    //[Route("Somar/{valor1}/{valor2}")]
    public float Somar(int valor1, int valor2)
    {
        return valor1 + valor2;
    }

    [HttpGet("Subtrair")]
    //[Route("Subtrair")]
    public float Subtrair(int valor1, int valor2)
    {
        return valor1 - valor2;
    }

    [HttpPost("Multiplicar")]
    public Resultado Multiplicar([FromBody] Valores valores)
    {
        var calculo = valores.Valor1 * valores.Valor2;
        var resultado = new Resultado(calculo, valores, "*");
        return resultado;
    }

    [HttpPut("Dividir")]
    public IActionResult Dividir([FromBody] Valores valores)
    {
        try
        {
            if (valores.Valor2 == 0)
                return BadRequest("O valor2 não pode ser zero");

            var calculo = valores.Valor1 / valores.Valor2;
            var resultado = new Resultado(calculo, valores, "/");

            //return StatusCode(200, resultado);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}