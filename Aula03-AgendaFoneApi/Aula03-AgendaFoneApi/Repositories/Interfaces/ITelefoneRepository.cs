using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Requests;

namespace Aula03_AgendaFoneApi.Repositories.Interfaces;

public interface ITelefoneRepository
{
    IEnumerable<Telefone> BuscarTodos();
    Telefone? BuscarPorId(int id);
    int Adicionar(TelefoneRequest telefone);
    int Alterar(TelefoneRequest telefone);
    int Apagar(int id);
}