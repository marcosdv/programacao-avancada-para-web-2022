namespace Aula03_AgendaFoneApi.Models;

public class Pessoa : Entidade
{
    public Pessoa(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public string Nome { get; private set; }
    public IList<Telefone> Telefones { get; private set; }
}