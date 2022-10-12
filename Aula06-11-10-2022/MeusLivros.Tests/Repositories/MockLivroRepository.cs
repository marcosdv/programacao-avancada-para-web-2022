using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Tests.Repositories;

public class MockLivroRepository : ILivroRepository
{
    private IList<Livro> _livros;

    public MockLivroRepository()
    {
        _livros = new List<Livro>();
        
        _livros.Add(CriarLivro(1, "Revista Alfa", 1));
        _livros.Add(CriarLivro(2, "Batman", 2));
        _livros.Add(CriarLivro(3, "SuperMan", 2));
        _livros.Add(CriarLivro(4, "Homem Aranha", 3));
    }

    private Livro CriarLivro(int id, string nome, int editora)
    {
        /*
        var livro = new Livro(id, nome, editora);
        livro.Editora = new MockEditoraRepository().BuscarPorId(editora);
        return livro;
        */
        return new Livro(id, nome, editora)
        {
            Editora = new MockEditoraRepository().BuscarPorId(editora)
        };
    }

    public IEnumerable<Livro> BuscarPorEditora(int IdEditora)
    {
        return _livros
            .AsQueryable()
            .Where(LivroQueries.BuscarPorEditora(IdEditora));
    }

    public Livro? BuscarPorId(int Id)
    {
        return _livros
            .AsQueryable()
            .Where(LivroQueries.BuscarPorId(Id))
            .FirstOrDefault();
    }

    public IEnumerable<Livro> BuscarTodos()
    {
        return _livros;
    }

    public void Inserir(Livro livro) { }

    public void Alterar(Livro livro) { }

    public void Excluir(Livro livro) { }
}