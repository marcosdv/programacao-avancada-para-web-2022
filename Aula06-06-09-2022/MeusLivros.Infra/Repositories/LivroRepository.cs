using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MeusLivros.Infra.Repositories;

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
            .Where(x => x.Editora.Id == IdEditora)
            .OrderBy(x => x.Nome);
    }

    public Livro? BuscarPorId(int Id)
    {
        return _context.Livros
            .Where(x => x.Id == Id)
            .FirstOrDefault();
    }

    public IEnumerable<Livro> BuscarTodos()
    {
        return _context.Livros
            .AsNoTracking()
            .OrderBy(x => x.Nome);
    }
}