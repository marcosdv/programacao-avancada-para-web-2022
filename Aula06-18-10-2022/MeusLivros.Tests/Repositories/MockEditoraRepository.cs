using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Tests.Repositories;

public class MockEditoraRepository : IEditoraRepository
{
    private IList<Editora> _editoras;

    public MockEditoraRepository()
    {
        _editoras = new List<Editora>();
        _editoras.Add(new Editora(1, "UniAlfa"));
        _editoras.Add(new Editora(2, "DC"));
        _editoras.Add(new Editora(3, "Marvel"));
    }

    public Editora? BuscarPorId(int id)
    {
        return _editoras
            .AsQueryable()
            .Where(EditoraQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<Editora> BuscarTodos()
    {
        return _editoras;
    }

    public void Inserir(Editora editora) { }

    public void Alterar(Editora editora) { }

    public void Excluir(Editora editora) { }
}