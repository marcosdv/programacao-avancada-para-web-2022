using MeusLivros.Domain.Entities;
using System.Linq.Expressions;

namespace MeusLivros.Domain.Queries;

public class EditoraQueries
{
    public static Expression<Func<Editora, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;
    }
}