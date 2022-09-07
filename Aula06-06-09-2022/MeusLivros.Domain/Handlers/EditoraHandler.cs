using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Domain.Handlers;

public class EditoraHandler :
    IHandler<EditoraInserirCommand>,
    IHandler<EditoraAlterarCommand>,
    IHandler<EditoraExcluirCommand>
{
    private readonly IEditoraRepository _repository;

    public EditoraHandler(IEditoraRepository repository)
    {
        _repository = repository;
    }

    #region Inserir

    public ICommandResult Handle(EditoraInserirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao inserir",
                                                command.Notificacoes);

        //criando a editora apartir dos dados do command
        var editora = new Editora(command.Nome);
        
        //inserindo no bando de dados
        _repository.Inserir(editora);

        return new CommandResult(true, "Editora inserida", editora);
    }

    #endregion

    #region Alterar

    public ICommandResult Handle(EditoraAlterarCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao alterar",
                                                command.Notificacoes);

        var editora = _repository.BuscarPorId(command.Id);

        if (editora == null)
            return new CommandResult(false, "Editora não encontrada", command);

        editora.Nome = command.Nome;

        _repository.Alterar(editora);

        return new CommandResult(true, "Editora alterada", editora);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(EditoraExcluirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao excluir",
                                                command.Notificacoes);

        var editora = _repository.BuscarPorId(command.Id);

        if (editora == null)
            return new CommandResult(false, "Editora não encontrada", command);

        _repository.Excluir(editora);
         
        return new CommandResult(true, "Editora excluída", editora);
    }

    #endregion
}