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

    public OperadoraController(IOperadoraRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        var result = _repository.BuscarOperadoras();

        if (result.Count > 0)
            return Ok(result);

        return NoContent();
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