using MeusLivros.Domain.Entities;

namespace MeusLivros.Domain.Repositories;

public interface IEditoraRepository
{
    void Inserir(Editora editora);
    void Alterar(Editora editora);
    void Excluir(Editora editora);
    IEnumerable<Editora> BuscarTodos();
    Editora? BuscarPorId(int id);
}