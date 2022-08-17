using Aula03_AgendaFoneApi.Models;

namespace Aula03_AgendaFoneApi.Repositories.Interfaces;

public interface IOperadoraRepository
{
    IList<Operadora> BuscarOperadoras();
    Operadora? BuscarPorId(int id);
    int Adicionar(string nome);
    int Alterar(Operadora operadora);
    int Apagar(int id);
}
