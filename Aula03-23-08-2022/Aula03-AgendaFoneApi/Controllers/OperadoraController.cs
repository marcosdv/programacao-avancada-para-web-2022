using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Repositories;
using Aula03_AgendaFoneApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
//leonardo
namespace Aula03_AgendaFoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    private readonly IOperadoraRepository _repository;
    private readonly ILogger<OperadoraController> _logger;

    public OperadoraController(IOperadoraRepository repository,
                               ILogger<OperadoraController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        try
        {
            _logger.LogInformation("Endpoint BuscarTodos acionado");

            var result = _repository.BuscarOperadoras();

            if (result.Count > 0)
                return Ok(result);

            _logger.LogWarning("Endpoint BuscarTodos não retornou dados");
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError("Endpoint BuscarTodos: " + ex.Message);
            return BadRequest();
        }
    }

    [HttpPost("{nome}")]
    public IActionResult Adicionar(string nome)
    {
        try
        {
            return Ok(_repository.Adicionar(nome));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Alterar([FromBody] Operadora operadora)
    {
        try
        {
            return Ok(_repository.Alterar(operadora));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Apagar(int id)
    {
        try
        {
            return Ok(_repository.Apagar(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var result = _repository.BuscarPorId(id);

        if (result != null)
            return Ok(result);

        return NoContent();
    }
}