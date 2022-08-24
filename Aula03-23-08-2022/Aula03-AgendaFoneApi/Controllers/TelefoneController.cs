using Aula03_AgendaFoneApi.Repositories.Interfaces;
using Aula03_AgendaFoneApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Aula03_AgendaFoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TelefoneController : ControllerBase
{
    private readonly ITelefoneRepository _repository;

    public TelefoneController(ITelefoneRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        var result = _repository.BuscarTodos();

        if (result.ToList().Count > 0)
            return Ok(result);

        return NoContent();
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] TelefoneRequest telefone)
    {
        try
        {
            return Ok(_repository.Adicionar(telefone));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Alterar([FromBody] TelefoneRequest telefone)
    {
        try
        {
            return Ok(_repository.Alterar(telefone));
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