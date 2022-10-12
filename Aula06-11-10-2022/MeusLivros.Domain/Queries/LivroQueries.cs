using MeusLivros.Domain.Entities;
using System.Linq.Expressions;

namespace MeusLivros.Domain.Queries;

public class LivroQueries
{
    public static Expression<Func<Livro, bool>> BuscarPorId(int id)
    {
        return livro => livro.Id == id;
    }

    public static Expression<Func<Livro, bool>> BuscarPorEditora(int idEditora)
    {
        return livro => livro.Editora.Id == idEditora;
    }
}