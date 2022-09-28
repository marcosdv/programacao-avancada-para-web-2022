using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MeusLivros.Infra.Repositories;

public class EditoraRepository : IEditoraRepository
{
    private readonly DataContext _context;

    public EditoraRepository(DataContext context)
    {
        _context = context;
    }

    public void Inserir(Editora editora)
    {
        _context.Editoras.Add(editora);
        _context.SaveChanges();
    }

    public void Alterar(Editora editora)
    {
        _context.Entry(editora).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Editora editora)
    {
        _context.Remove(editora);
        _context.SaveChanges();
    }

    public Editora? BuscarPorId(int id)
    {
        return _context.Editoras
            //.Where(x => x.Id == id)
            .Where(EditoraQueries.BuscarPorId(id))
            .FirstOrDefault();
    }

    public IEnumerable<Editora> BuscarTodos()
    {
        return _context.Editoras
            .AsNoTracking()
            .Include(x => x.Livros)
            .OrderBy(x => x.Nome);
    }
}