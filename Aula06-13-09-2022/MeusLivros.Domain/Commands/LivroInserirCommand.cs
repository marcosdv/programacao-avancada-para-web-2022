using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands;

public class LivroInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }
    public int IdEditora { get; set; }

    public LivroInserirCommand() { }

    public LivroInserirCommand(string nome, int idEditora)
    {
        Nome = nome;
        IdEditora = idEditora;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (IdEditora <= 0)
            AdicionarNotificacao("A editora deve ser informada");
    }
}