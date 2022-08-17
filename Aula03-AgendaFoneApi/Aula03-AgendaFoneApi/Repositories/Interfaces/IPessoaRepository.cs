using Aula03_AgendaFoneApi.Models;
using Aula03_AgendaFoneApi.Requests;

namespace Aula03_AgendaFoneApi.Repositories.Interfaces;

public interface IPessoaRepository
{
    IEnumerable<Pessoa> BuscarPessoas();
    Pessoa? BuscarPorId(int id);
    int Adicionar(PessoaRequest pessoa);
    int Alterar(PessoaRequest pessoa);
    int Apagar(int id);
}