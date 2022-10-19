using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroRepository _repository;
    private readonly LivroHandler _handler;

    public LivroController(ILivroRepository repository, LivroHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }

    [HttpGet]
    public IEnumerable<Livro> BuscarTodos()
    {
        return _repository.BuscarTodos();
    }

    [HttpGet("{id}")]
    public Livro? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    [HttpGet("editora/{id}")]
    public IEnumerable<Livro> BuscarPorEditora(int id)
    {
        return _repository.BuscarPorEditora(id);
    }

    [Authorize] //adiciona validacao JWT no metodo Inserir
    [HttpPost]
    public CommandResult Inserir(LivroInserirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [Authorize] //adiciona validacao JWT no metodo Alterar
    [HttpPut]
    public CommandResult Alterar(LivroAlterarCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [Authorize] //adiciona validacao JWT no metodo Excluir
    [HttpDelete]
    public CommandResult Excluir(LivroExcluirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }
}