namespace MeusLivros.Domain.Validations;

public abstract class Notificavel
{
    private readonly List<string> _notificacoes;

    public Notificavel()
    {
        _notificacoes = new List<string>();
    }

    public void AdicionarNotificacao(string mensagem)
    {
        _notificacoes.Add(mensagem);
    }

    public IReadOnlyCollection<string> Notificacoes => _notificacoes;

    public bool isInvalida => _notificacoes.Any();

    public bool isValida => !isInvalida;
}