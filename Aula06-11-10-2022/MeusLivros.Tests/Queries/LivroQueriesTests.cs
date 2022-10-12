using MeusLivros.Domain.Repositories;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Queries;

[TestClass]
public class LivroQueriesTests
{
    private ILivroRepository _repository;

    public LivroQueriesTests()
    {
        _repository = new MockLivroRepository();
    }

    #region BuscarPorId Tests

    [TestMethod]
    public void AoRealizarUmaConsultaComIdExistenteDeveRetornarUmLivro()
    {
        var result = _repository.BuscarPorId(1);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void AoRealizarUmaConsultaComIdInexistenteDeveRetornarNulo()
    {
        var result = _repository.BuscarPorId(5);

        Assert.IsNull(result);
    }

    #endregion

    #region BuscarPorEditora Tests

    [TestMethod]
    public void AoRealizarUmaConsultaPorEditoraDeveRetornarUmLivroDela()
    {
        var result = _repository.BuscarPorEditora(1);

        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void AoRealizarUmaConsultaPorEditoraDeveRetornarDoisLivrosDela()
    {
        var result = _repository.BuscarPorEditora(2);

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void AoRealizarUmaConsultaPorEditoraInexistenteDeveRetornarZero()
    {
        var result = _repository.BuscarPorEditora(4);

        Assert.AreEqual(0, result.Count());
    }

    #endregion
}