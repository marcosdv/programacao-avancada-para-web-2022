using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Handlers;

[TestClass]
public class EditoraHandlerTests
{
    private readonly IEditoraRepository _repository;
    private readonly EditoraHandler _handler;

    public EditoraHandlerTests()
    {
        _repository = new MockEditoraRepository();
        _handler = new EditoraHandler(_repository);
    }

    #region Inserir Testes

    [TestMethod]
    public void DadoUmComandoInserirValidoRetornaSucessoTrue()
    {
        var command = new EditoraInserirCommand("Nome");

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoInserirInvalidoRetornaSucessoFalse()
    {
        var command = new EditoraInserirCommand();

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    #endregion

    #region Alterar Testes

    [TestMethod]
    public void DadoUmComandoAlterarValidoDeveRetornarSucessoTrue()
    {
        var command = new EditoraAlterarCommand(1, "Nome");

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoAlterarInvalidoDeveRetornarSucessoFalse()
    {
        var command = new EditoraAlterarCommand(0, "");

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoAlterarValidoMasComEditoraInexistenteDeveRetornarSucessoFalse()
    {
        var command = new EditoraAlterarCommand(9, "Nome");

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    #endregion

    #region Excluir Testes

    [TestMethod]
    public void DadoUmComandoExcluirValidoDeveRetornarSucessoTrue()
    {
        var command = new EditoraExcluirCommand(1);

        var result = _handler.Handle(command);

        Assert.IsTrue((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoExcluirInvalidoDeveRetornarSucessoFalse()
    {
        var command = new EditoraExcluirCommand();

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoExcluirValidoMasComEditoraInexistenteDeveRetornarSucessoFalse()
    {
        var command = new EditoraExcluirCommand(9);

        var result = _handler.Handle(command);

        Assert.IsFalse((result as CommandResult).Sucesso);
    }

    #endregion
}
