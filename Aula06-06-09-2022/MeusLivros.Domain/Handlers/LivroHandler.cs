using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Domain.Handlers;

public class LivroHandler :
    IHandler<LivroInserirCommand>,
    IHandler<LivroAlterarCommand>,
    IHandler<LivroExcluirCommand>
{
    private readonly ILivroRepository _livroRepository;

    public LivroHandler(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    #region Inserir

    public ICommandResult Handle(LivroInserirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao incluir", 
                                            command.Notificacoes);

        var livro = new Livro(command.Nome, command.IdEditora);

        _livroRepository.Inserir(livro);

        return new CommandResult(true, "Livro inserido", livro);
    }

    #endregion

    #region Alterar

    public ICommandResult Handle(LivroAlterarCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao alterar",
                                                command.Notificacoes);

        var livro = _livroRepository.BuscarPorId(command.Id);

        if (livro == null)
            return new CommandResult(false, "Livro não encontrado",
                                                command.Notificacoes);

        livro.Nome = command.Nome;
        livro.EditoraId = command.IdEditora;

        _livroRepository.Alterar(livro);

        return new CommandResult(true, "Livro alterado", livro);
    }

    #endregion

    #region Excluir

    public ICommandResult Handle(LivroExcluirCommand command)
    {
        command.Validar();
        if (command.isInvalida)
            return new CommandResult(false, "Erro ao excluir",
                                            command.Notificacoes);

        var livro = _livroRepository.BuscarPorId(command.Id);

        if (livro == null)
            return new CommandResult(false, "Livro não encontrado",
                                            command.Notificacoes);

        _livroRepository.Excluir(livro);

        return new CommandResult(true, "Livro excluído", livro);
    }

    #endregion
}