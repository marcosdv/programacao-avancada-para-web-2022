using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;
using System.Diagnostics.CodeAnalysis;

namespace MeusLivros.Domain.Commands;

public class EditoraAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }

    [ExcludeFromCodeCoverage]
    public EditoraAlterarCommand() { }

    public EditoraAlterarCommand(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");
    }
}