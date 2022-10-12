using MeusLivros.Domain.Repositories;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Queries;

[TestClass]
public class EditoraQueriesTests
{
    private IEditoraRepository _repository;

    public EditoraQueriesTests()
    {
        _repository = new MockEditoraRepository();
    }

    [TestMethod]
    public void AoRealizarUmaConsultaComIdExistenteDeveRetornarUmaEditora()
    {
        var result = _repository.BuscarPorId(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void AoRealizarUmaConsultaComIdInexistenteDeveRetornarNulo()
    {
        var result = _repository.BuscarPorId(4);

        Assert.IsNull(result);
    }
}