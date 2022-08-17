using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Repositories.Interfaces;
using Aula03_AgendaFoneApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Aula03_AgendaFoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _repository;

    public PessoaController(IPessoaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        var result = _repository.BuscarPessoas();

        if (result.ToList().Count > 0)
            return Ok(result);

        return NoContent();
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] PessoaRequest pessoa)
    {
        try
        {
            return Ok(_repository.Adicionar(pessoa));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Alterar([FromBody] PessoaRequest pessoa)
    {
        try
        {
            return Ok(_repository.Alterar(pessoa));
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