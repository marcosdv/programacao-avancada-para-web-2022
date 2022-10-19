namespace MeusLivros.Domain.Entities;

public class Editora : Entity
{
    public string Nome { get; set; }
    public IList<Livro> Livros { get; set; }

    public Editora(string nome)
    {
        Nome = nome;
        Livros = new List<Livro>();
    }

    public Editora(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Livros = new List<Livro>();
    }

    public Editora()
    {
        Livros = new List<Livro>();
    }
}