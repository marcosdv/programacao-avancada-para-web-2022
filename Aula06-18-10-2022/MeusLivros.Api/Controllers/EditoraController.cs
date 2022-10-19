using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers;

[Authorize] //adiciona validacao JWT na controller inteira
[Route("api/[controller]")]
[ApiController]
public class EditoraController : ControllerBase
{
    private readonly IEditoraRepository _repository;

    public EditoraController(IEditoraRepository repository)
    {
        _repository = repository;
    }

    [AllowAnonymous] //remove validacao JWT no metodo BuscarTodos
    [HttpGet]
    public IEnumerable<Editora> BuscarTodos([FromServices] IEditoraRepository repository)
    {
        return repository.BuscarTodos();
    }

    [HttpGet("{id}")]
    public Editora? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    [HttpPost]
    public CommandResult Inserir(EditoraInserirCommand command,
        [FromServices]EditoraHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    [HttpPut]
    public CommandResult Alterar(EditoraAlterarCommand command,
        [FromServices] EditoraHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    [HttpDelete]
    public CommandResult Excluir(EditoraExcluirCommand command,
        [FromServices] EditoraHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }
}