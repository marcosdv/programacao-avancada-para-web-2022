using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Repositories.Interfaces;
using Aula03_AgendaFoneApi.Requests;

namespace Aula03_AgendaFoneApi.Repositories;

public class TelefoneRepository : ITelefoneRepository
{
    public int Adicionar(TelefoneRequest telefone)
    {
        throw new NotImplementedException();
    }

    public int Alterar(TelefoneRequest telefone)
    {
        throw new NotImplementedException();
    }

    public int Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Telefone? BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Telefone> BuscarTodos()
    {
        throw new NotImplementedException();
    }
}