using MeusLivros.Domain.Commands.Interfaces;

namespace MeusLivros.Domain.Commands;

public class CommandResult : ICommandResult
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Dados { get; set; }

    public CommandResult(bool sucesso, string mensagem, object dados)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Dados = dados;
    }

    public CommandResult() { }
}