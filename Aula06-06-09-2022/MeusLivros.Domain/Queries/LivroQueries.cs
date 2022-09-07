using MeusLivros.Domain.Entities;
using System.Data;
using System.Linq.Expressions;

namespace MeusLivros.Domain.Queries;

public class LivroQueries
{
    public static Expression<Func<Livro, bool>> BuscarPorId(int id)
    {
        return livro => livro.Id == id;
    }

    public static Expression<Func<Livro, bool>> BuscarPorEditora(Editora editora)
    {
        return livro => livro.Editora == editora;
    }
}