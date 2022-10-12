using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands;

public class LivroAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int IdEditora { get; set; }

    public LivroAlterarCommand() { }

    public LivroAlterarCommand(int id, string nome, int idEditora)
    {
        Id = id;
        Nome = nome;
        IdEditora = idEditora;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("O Código deve ser informado");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (IdEditora <= 0)
            AdicionarNotificacao("A editora deve ser informada");
    }
}