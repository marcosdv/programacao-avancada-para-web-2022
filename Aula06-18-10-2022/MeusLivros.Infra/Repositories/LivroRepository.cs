using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Queries;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MeusLivros.Infra.Repositories;

[ExcludeFromCodeCoverage]
public class LivroRepository : ILivroRepository
{
    private readonly DataContext _context;

    public LivroRepository(DataContext context)
    {
        _context = context;
    }

    public void Inserir(Livro livro)
    {
        _context.Livros.Add(livro);
        _context.SaveChanges();
    }

    public void Alterar(Livro livro)
    {
        _context.Entry(livro).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Livro livro)
    {
        _context.Remove(livro);
        _context.SaveChanges();
    }

    public IEnumerable<Livro> BuscarPorEditora(int IdEditora)
    {
        return _context.Livros
            .AsNoTracking()
            .Include(x => x.Editora)
            .Where(LivroQueries.BuscarPorEditora(IdEditora))
            .OrderBy(x => x.Nome);
    }

    public Livro? BuscarPorId(int Id)
    {
        return _context.Livros
            .Where(LivroQueries.BuscarPorId(Id))
            .FirstOrDefault();
    }

    public IEnumerable<Livro> BuscarTodos()
    {
        return _context.Livros
            .AsNoTracking()
            .Include(x => x.Editora)
            .OrderBy(x => x.Nome);
    }
}