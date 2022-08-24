namespace Aula03_AgendaFoneApi.Models;

public class Pessoa : Entidade
{
    public Pessoa()
    {
        Telefones = new List<Telefone>();
    }

    public Pessoa(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Telefones = new List<Telefone>();
    }

    public string Nome { get; private set; }
    public IList<Telefone> Telefones { get; private set; }

    public void adicionarTelefone(Telefone telefone)
    {
        Telefones.Add(telefone);
    }
}